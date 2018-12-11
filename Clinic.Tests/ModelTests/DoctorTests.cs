using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clinic.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clinic.Tests
{
    [TestClass]
    public class DoctorTest: IDisposable
    {
        public void Dispose()
        {
            Doctor.ClearAll();
        }

        public DoctorTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=clinic_test;";
        }

        [TestMethod]
        public void Create_CreatesTypeOfDoctor_Doctor()
        {
            Doctor testDoc = new Doctor("bob", 1);
            Assert.AreEqual(testDoc.GetType(), typeof(Doctor));
        }

        [TestMethod]
        public void Name_GetName_Name()
        {
            string name = "Dr Frankenstein";
            Doctor testDoc = new Doctor(name);
            string resultName = testDoc.GetName();
            Assert.AreEqual(name, resultName);
        }

        [TestMethod]
        public void Save_SavesToDatabase_Doctor()
        {
            Doctor testDoc = new Doctor("bob", 1);
            testDoc.Save();
            List<Doctor> resultList = Doctor.GetAll();
            Doctor resultDoc = resultList[0];
            Console.WriteLine(testDoc.GetName());
            Console.WriteLine(resultDoc.GetName());
            Assert.AreEqual(testDoc, resultDoc);
        }

        [TestMethod]
        public void GetAll_ReturnsAllInList_List()
        {
            Doctor docOne = new Doctor("bob");
            Doctor docTwo = new Doctor("frank");
            docOne.Save();
            docTwo.Save();
            List<Doctor> testList = new List<Doctor>{docOne, docTwo};
            List<Doctor> resultList = Doctor.GetAll();
            CollectionAssert.AreEqual(testList, resultList);
        }


    }
}
