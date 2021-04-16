using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
//using Moq;
//using Xunit;
using EsCodeChallenge.Pages;
using Microsoft.Extensions.Logging;

namespace EsCodeChallengeTest
{
    [TestClass]
    public class IndexPageTests
    {
        [TestMethod]
        public void OnGet_PopulatesThePageModel_WithAListOfResults()
        {
            #region snippet1
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<IndexModel>();
            var pageModel = new IndexModel(logger);
            #endregion

            #region snippet2
            // Act
            pageModel.OnGet();
            #endregion

            #region snippet3
            // Assert
            Assert.IsNotNull(pageModel.Results);
            #endregion
        }

        [TestMethod]
        public void OnPost_PopulatesThePageModel_WithAListOfResults()
        {
            #region snippet1
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<IndexModel>();
            var pageModel = new IndexModel(logger);
            #endregion

            #region snippet2
            // Act
            pageModel.Version = "0.0";
            pageModel.OnPost();
            #endregion

            #region snippet3
            // Assert
            Assert.IsNotNull(pageModel.Results);
            #endregion
        }

        [TestMethod]
        public void OnPost_PopulatesThePageModel_WithAFIlteredListOfResults()
        {
            #region snippet1
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<IndexModel>();
            var pageModel = new IndexModel(logger);
            #endregion

            #region snippet2
            // Act
            pageModel.Version = "2019";
            pageModel.OnPost();
            #endregion

            #region snippet3
            // Assert
            Assert.IsNotNull(pageModel.Results);
            var actualResultsCount = pageModel.Results.Count();
            var expectedResultsCount = 1;
            Assert.AreEqual(expectedResultsCount, actualResultsCount);
            #endregion
        }

        [TestMethod]
        public void OnPost_PopulatesThePageModel_WithAFIlteredListOfNoResults()
        {
            #region snippet1
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<IndexModel>();
            var pageModel = new IndexModel(logger);
            #endregion

            #region snippet2
            // Act
            pageModel.Version = "2019.1";
            pageModel.OnPost();
            #endregion

            #region snippet3
            // Assert
            Assert.IsNotNull(pageModel.Results);
            var actualResultsCount = pageModel.Results.Count();
            var expectedResultsCount = 0;
            Assert.AreEqual(expectedResultsCount, actualResultsCount);
            #endregion
        }

        [TestMethod]
        public void OnPost_ValidationError_VersionFormatIncorrect()
        {
            #region snippet1
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<IndexModel>();
            var pageModel = new IndexModel(logger);
            #endregion

            #region snippet2
            // Act
            pageModel.Version = "aa.bb.cc";
            pageModel.OnPost();
            #endregion

            #region snippet3
            // Assert
            Assert.IsFalse(pageModel.ModelState.IsValid);
            #endregion
        }
    }
}
