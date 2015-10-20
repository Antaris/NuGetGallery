// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Xunit;

namespace NuGetGallery.Packaging
{
    public class PackageIdValidatorTest
    {
        [Fact]
        public void ValidatePackageIdInvalidIdThrows()
        {
            // Arrange
            string packageId = "  Invalid  . Woo   .";

            // Act & Assert
            Exception thrownException = null;
            try
            {
                PackageIdValidator.ValidatePackageId(packageId);
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.NotNull(thrownException);
            Assert.Equal("The package ID '  Invalid  . Woo   .' contains invalid characters. Examples of valid package IDs include 'MyPackage' and 'MyPackage.Sample'.", thrownException.Message);
        }

        [Fact]
        public void EmptyIsNotValid()
        {
            // Arrange
            string packageId = "";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void NullThrowsException()
        {
            // Arrange
            string packageId = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>("packageId", 
                () => PackageIdValidator.IsValidPackageId(packageId));
        }

        [Fact]
        public void AlphaNumericIsValid()
        {
            // Arrange
            string packageId = "42This1Is4You";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void MultipleDotSeparatorsAllowed()
        {
            // Arrange
            string packageId = "I.Like.Writing.Unit.Tests";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void NumbersAndWordsDotSeparatedAllowd()
        {
            // Arrange
            string packageId = "1.2.3.4.Uno.Dos.Tres.Cuatro";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void UnderscoreDotAndDashSeparatorsAreValid()
        {
            // Arrange
            string packageId = "Nu_Get.Core-IsCool";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void NonAlphaNumericUnderscoreDotDashIsInvalid()
        {
            // Arrange
            string packageId = "ILike*Asterisks";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void ConsecutiveSeparatorsNotAllowed()
        {
            // Arrange
            string packageId = "I_.Like.-Separators";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void StartingWithSeparatorsNotAllowed()
        {
            // Arrange
            string packageId = "-StartWithSeparator";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void EndingWithSeparatorsNotAllowed()
        {
            // Arrange
            string packageId = "StartWithSeparator.";

            // Act
            bool isValid = PackageIdValidator.IsValidPackageId(packageId);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(102)]
        [InlineData(200)]
        public void IdExceedingMaxLengthThrows(int idTestLength)
        {
            // Arrange
            string packageId = new string('d', idTestLength);

            // Act && Assert
            Exception thrownException = null;
            try
            {
                PackageIdValidator.ValidatePackageId(packageId);
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.NotNull(thrownException);
            Assert.Equal("Id must not exceed 100 characters.", thrownException.Message);
        }
    }
}