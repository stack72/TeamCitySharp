namespace TeamCitySharp.ActionTypes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DomainEntities;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;
    using Connection;

    [TestFixture]
    public class ArtifactDownloaderTest
    {
        #region Attributes

        private ITeamCityCaller _teamCityCaller;
        private ISystemIOWrapper _systemIOWrapper;
        private ArtifactDownloader _testee;
        private string _destinationDir;
        private string _artifactFileName;

        #endregion Attributes

        #region Common Test Setup & Teardown

        [SetUp]
        public void Setup()
        {
            _destinationDir = @"C:\testdir";
            _artifactFileName = "file1.cs";
            _teamCityCaller = A.Fake<ITeamCityCaller>();
            _systemIOWrapper = A.Fake<ISystemIOWrapper>();
            _testee = new ArtifactDownloader(_teamCityCaller, _systemIOWrapper);
        }

        #endregion Common Test Setup & Teardown

        #region Tests

        [Test]
        public void it_throws_if_artifacts_null()
        {
            _testee.Invoking(testee => testee.Download(null, string.Empty, string.Empty, false, true, false)).ShouldThrow<ArgumentException>();
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void it_uses_current_directory_if_none_provided(string destinationDir)
        {
            var artifacts = SetupEmptyArtifacts();

            _testee.Download(artifacts, string.Empty, destinationDir, false, true, false);

            A.CallTo(() => _systemIOWrapper.GetCurrentDirectory()).MustHaveHappened();
        }

        [Test]
        public void it_throws_if_any_artifact_url_invalid()
        {
            var artifacts = SetupInvalidArtifact();

            _testee.Invoking(testee => testee.Download(artifacts, string.Empty, string.Empty, false, true, false)).ShouldThrow<ArgumentException>();
        }

        [Test]
        public void it_creates_destination_path_if_not_exists()
        {
            var artifacts = SetupArtifactUnderRelativeName(string.Empty, _artifactFileName);
            A.CallTo(() => _systemIOWrapper.DirectoryExists(_destinationDir)).Returns(false);

            _testee.Download(artifacts, string.Empty, _destinationDir, false, true, false);

            A.CallTo(() => _systemIOWrapper.CreateDirectory(_destinationDir)).MustHaveHappened();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void it_deletes_existing_files_if_overwrite(bool overwrite)
        {
            var artifacts = SetupArtifactUnderRelativeName(string.Empty, _artifactFileName);
            var filePathToOverwrite = Path.Combine(_destinationDir, _artifactFileName);

            A.CallTo(() => _systemIOWrapper.FileExists(filePathToOverwrite)).Returns(true);

            _testee.Download(artifacts, string.Empty, _destinationDir, false, overwrite, false);

            if (overwrite)
            {
                A.CallTo(() => _systemIOWrapper.DeleteFile(filePathToOverwrite)).MustHaveHappened();
            }
            else
            {
              A.CallTo(() => _systemIOWrapper.DeleteFile(filePathToOverwrite)).MustNotHaveHappened();
            }
        }

        [Test]
        public void it_saves_simple_artifacts()
        {
            var artifacts = SetupArtifactUnderRelativeName(string.Empty, _artifactFileName);

            var downloadedFiles = _testee.Download(artifacts, string.Empty, _destinationDir, false, true, false);

            AssertFileDownloadedToCorrectPath(downloadedFiles, _destinationDir, artifacts);
        }

        [Test]
        [TestCase("", false, @"")]
        [TestCase("subdir1", false, @"subdir1")]
        [TestCase("subdir1/subdir2", false, @"subdir1\subdir2")]
        [TestCase("subdir1/archive.zip!", true, @"subdir1\archive.zip")]
        [TestCase("archive.zip!", true, @"archive.zip")]
        [TestCase("archive.zip!/subdir2", true, @"archive.zip\subdir2")]
        [TestCase("archive1.zip!/archive2.zip!", true, @"archive1.zip\archive2.zip")]
        [TestCase("subdir1/archive.zip!/subdir2", true, @"subdir1\archive.zip\subdir2")]
        public void it_saves_artifacts_in_subfolders(string subFolderPath, bool extractArchives, string expectedSubFolderPath)
        {
            var artifacts = SetupArtifactUnderRelativeName(subFolderPath, _artifactFileName);

            var downloadedFiles = _testee.Download(artifacts, string.Empty, _destinationDir, false, true, extractArchives);

            AssertFileDownloadedToCorrectPath(downloadedFiles, Path.Combine(_destinationDir, expectedSubFolderPath), artifacts);
        }

        [Test]
        [TestCase("", false)]
        [TestCase("subdir1", false)]
        [TestCase("subdir1/subdir2", false)]
        [TestCase("subdir1/archive.zip!", true)]
        [TestCase("archive.zip!", true)]
        [TestCase("archive.zip!/subdir2", true)]
        [TestCase("archive1.zip!/archive2.zip!", true)]
        [TestCase("subdir1/archive.zip!/subdir2", true)]
        public void it_excludes_artifactRelativeName_from_destination_directory(string artifactRelativeName, bool extractArchives)
        {
            var artifacts = SetupArtifactUnderRelativeName(artifactRelativeName, _artifactFileName);

            var downloadedFiles = _testee.Download(artifacts, artifactRelativeName, _destinationDir, false, true, extractArchives);

            AssertFileDownloadedToCorrectPath(downloadedFiles, _destinationDir, artifacts);
        }

        [Test]
        [TestCase("", false)]
        [TestCase("subdir1", false)]
        [TestCase("subdir1/subdir2", false)]
        [TestCase("subdir1/archive.zip!", true)]
        [TestCase("archive.zip!", true)]
        [TestCase("archive.zip!/subdir2", true)]
        [TestCase("archive1.zip!/archive2.zip!", true)]
        [TestCase("subdir1/archive.zip!/subdir2", true)]
        public void it_ignores_artifacts_within_archives_by_default(string subFolderPath, bool ignoreExpected)
        {
            var artifacts = SetupArtifactUnderRelativeName(subFolderPath, _artifactFileName);

            var downloadedFiles = _testee.Download(artifacts, string.Empty, _destinationDir, false, true, false);

            var reason = ignoreExpected ? "file is located inside an archive" : "file is not located inside an archive";
            downloadedFiles.Count.Equals(0).Should().Be(ignoreExpected, reason);
        }

        [Test]
        [TestCase("", false)]
        [TestCase("subdir1", false)]
        [TestCase("subdir1/subdir2", false)]
        [TestCase("subdir1/archive.zip!", true)]
        [TestCase("archive.zip!", true)]
        [TestCase("archive.zip!/subdir2", true)]
        [TestCase("archive1.zip!/archive2.zip!", true)]
        [TestCase("subdir1/archive.zip!/subdir2", true)]
        public void it_flattens_directories(string subFolderPath, bool extractArchives)
        {
            var artifacts = SetupArtifactUnderRelativeName(subFolderPath, _artifactFileName);

            var downloadedFiles = _testee.Download(artifacts, string.Empty, _destinationDir, true, true, extractArchives);

            AssertFileDownloadedToCorrectPath(downloadedFiles, _destinationDir, artifacts);
        }

        [Test]
        [TestCase("subdir", false)]
        [TestCase("archive.zip", true)]
        public void it_retrieves_content_of_folders_and_archives(string artifactFolderName, bool extractArchives)
        {
            var artifacts = SetupArtifactFolder(artifactFolderName, extractArchives);
            A.CallTo(() => _teamCityCaller.Get<Artifacts>(artifacts.Files[0].Children.Href))
             .Returns(SetupArtifactUnderRelativeName(string.Format("{0}{1}", artifactFolderName, extractArchives ? "!" : string.Empty), _artifactFileName));

            var downloadedFiles = _testee.Download(artifacts, string.Empty, _destinationDir, false, true, extractArchives);

            AssertFileDownloadedToCorrectPath(downloadedFiles, Path.Combine(_destinationDir, artifactFolderName), artifacts);
        }

        #endregion Tests

        #region Artifact Setup Methods

        private Artifacts SetupArtifactUnderRelativeName(string artifactRelativeName, string artifactFileName)
        {
            return new Artifacts
            {
                Files = new List<Artifact>
                    {
                        new Artifact
                          {
                              Content = new HrefWrapper { Href = string.Format("/app/rest/builds/id:0/artifacts/content/{0}/{1}", artifactRelativeName, artifactFileName) }, 
                              Href = string.Format("/app/rest/builds/id:0/artifacts/metadata/{0}/{1}", artifactRelativeName, artifactFileName), 
                              Size = 1, 
                              Name = artifactFileName
                          },
                    }
            };
        }

        private Artifacts SetupArtifactFolder(string artifactFolderName, bool isArchive)
        {
            return new Artifacts
            {
                Files = new List<Artifact>
                        {
                            new Artifact
                              {
                                  Content = isArchive ? new HrefWrapper { Href = string.Format("/app/rest/builds/id:0/artifacts/content/{0}", artifactFolderName) } : null, 
                                  Children = new HrefWrapper { Href = string.Format("/app/rest/builds/id:0/artifacts/children/{0}", artifactFolderName) }, 
                                  Href = string.Format("/app/rest/builds/id:0/artifacts/metadata/{0}", artifactFolderName), 
                                  Size = (ulong) (isArchive ? 1 : 0), 
                                  Name = artifactFolderName
                              },
                        }
            };
        }

        private Artifacts SetupInvalidArtifact()
        {
            return new Artifacts
            {
                Files = new List<Artifact>
                        {
                            new Artifact
                              {
                                Content = new HrefWrapper { Href = "some/invalid/url/content/" }, 
                                Href = "some/invalid/url/metadata", 
                                Size = 1, 
                                Name = "some.file"
                              },
                        }
            };
        }

        private Artifacts SetupEmptyArtifacts()
        {
            return new Artifacts { Files = new List<Artifact>() };
        }

        #endregion  Artifact Setup Methods

        #region Assertion Methods

        private void AssertFileDownloadedToCorrectPath(List<string> downloadedFiles, string destinationFolder, Artifacts artifacts)
        {
            downloadedFiles.Count.Should().Be(artifacts.Files.Count, "unexpected number of files downloadeded");
            downloadedFiles[0].Should().Be(Path.Combine(destinationFolder, _artifactFileName));
        }

        #endregion
    }
}
