namespace UnitTests
{
    using Entities;
    using Dal;

    public class UnitTests
    {

        [Fact]
        public void CanGetFromDatabase()
        {
            //Arrange
            NorthwindContext context;
            UnitOfWork unitOfWork;

            //Act
            context = new NorthwindContext();
            unitOfWork = new(context);

            //Assert
            Assert.True(unitOfWork.CustomerRepository.GetCustomerByCompanyName("Bon App'") != null);
        }
        
        [Fact]
        public void CanAddToDatabase()
        {
            //Arrange
            NorthwindContext context;
            Customer customerToAdd;
            UnitOfWork unitOfWork;

            //Act
            context = new NorthwindContext();
            unitOfWork = new(context);
            customerToAdd = new Customer()
            {
                CustomerId = "TSTMP",
                CompanyName = "TestCompany",
                Address = "TestAddress",
                City = "TestCity",
                ContactName = "TestContact",
                ContactTitle = "TestTitle",
                PostalCode = "0000",
                Phone = "00000000",
                Country = "TestCountry"
            };


            unitOfWork.CustomerRepository.Insert(customerToAdd);
            unitOfWork.Save();

            //assert
            Assert.NotNull(unitOfWork.CustomerRepository.GetCustomerByCompanyName(customerToAdd.CompanyName));
            Assert.Equal("TestCountry", unitOfWork.CustomerRepository.GetCustomerByCompanyName(customerToAdd.CompanyName).First().Country);
            Assert.Contains(customerToAdd, unitOfWork.CustomerRepository.Get());


            unitOfWork.CustomerRepository.Delete(customerToAdd);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }

        [Fact]
        public void CanDeleteFromDataBase()
        {
            //Arrange
            NorthwindContext context;
            UnitOfWork unitOfWork;
            Customer customerToAdd;


            //Act
            context = new NorthwindContext();
            unitOfWork = new(context);
            customerToAdd = new Customer()
            {
                CustomerId = "TSTMP",
                CompanyName = "TestCompany",
                Address = "TestAddress",
                City = "TestCity",
                ContactName = "TestContact",
                ContactTitle = "TestTitle",
                PostalCode = "0000",
                Phone = "00000000",
                Country = "TestCountry"
            };


            unitOfWork.CustomerRepository.Insert(customerToAdd);
            unitOfWork.CustomerRepository.Delete(customerToAdd);

            //Assert
            Assert.DoesNotContain(customerToAdd, unitOfWork.CustomerRepository.Get());
            Assert.Null(unitOfWork.CustomerRepository.GetByID("TSTMP"));
        }

        [Fact]
        public void CanUpdateWithUnitOfWork()
        {
            NorthwindContext context;
            UnitOfWork unitOfWork;
            Customer customerToAdd;


            //Act
            context = new NorthwindContext();
            unitOfWork = new(context);
            customerToAdd = new Customer()
            {
                CustomerId = "TSTMP",
                CompanyName = "TestCompany",
                Address = "TestAddress",
                City = "TestCity",
                ContactName = "TestContact",
                ContactTitle = "TestTitle",
                PostalCode = "0000",
                Phone = "00000000",
                Country = "TestCountry"
            };
            unitOfWork.CustomerRepository.Insert(customerToAdd);
            unitOfWork.Save();

            customerToAdd.ContactName = "UpdatedTestCompany";
            unitOfWork.CustomerRepository.Update(customerToAdd);
            unitOfWork.Save();



            Assert.True(unitOfWork.CustomerRepository.GetByID("TSTMP").ContactName == "UpdatedTestCompany");

            unitOfWork.CustomerRepository.Delete(unitOfWork.CustomerRepository.GetByID("TSTMP"));
            unitOfWork.Save();

        }
    }
}