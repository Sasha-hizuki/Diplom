using AutoMapper;
using logistic_app_api.Controllers;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Cars;
using logistic_app_api.Models;
using Moq;
using System;
using Xunit;

namespace unitTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetListUserNotNull()
        {
            var mock = new Mock<CarsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new CarsController(mock.Object, mock1.Object);


            // Act
            var result = controller.GetAll();

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void DeleteStoreTest()
        {
            var mock = new Mock<CarsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new CarsController(mock.Object, mock1.Object);


            // Act
            var result = controller.Delete(1);


        }

        [Fact]
        public void CreateNewCarTest()
        {
            var mock = new Mock<CarsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new CarsController(mock.Object, mock1.Object);


            var modelList = new CarCreateDto(){};

            var result = controller.Create(modelList);


        }

        [Fact]
        public void GetAllDeclarants()
        {
            var mock = new Mock<IRepository<Declarant>>();
            var mock1 = new Mock<IMapper>();
            var controller = new DeclarantsController(mock.Object, mock1.Object);

            var result = controller.GetAll();

            Assert.NotNull(result);
                
        }

        [Fact]

        public void ActionUpdateTest()
        {
            var mock = new Mock<DeclarantsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new DeclarantsController(mock.Object, mock1.Object);


            var modelList = new Declarant()
            {
                Id = 1
            };

            var result = controller.Delete(modelList.Id);


        }
        [Fact]
        public void GetByIdTest()
        {
            var mock = new Mock<DeclarantsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new DeclarantsController(mock.Object, mock1.Object);


            var modelList = new Declarant()
            {
                
                Id = 3
            };

            var result = controller.GetById(modelList.Id);

            Assert.NotNull(result);


        }

        [Fact]
        public void IndexChekNotNull()
        {
            var mock = new Mock<DestinationsRepository>();
            var mock1 = new Mock<IMapper>();
            var controller = new DestinationsController(mock.Object, mock1.Object);

            var result = controller.GetAll();

            Assert.NotNull(result);
        }
    }
}