using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestClass
    {
        WpfApp.Model model;
        AssemblyBrowsing.AssemblyInformation assembly;
        [TestInitialize]
        public void TestInit()
        {
            model = new WpfApp.Model();
            assembly = model.LoadAssembly("C:\\Users\\User\\Desktop\\ÑÏÏ\\ÑÏÏ3\\TestProject\\bin\\Debug\\TestProject.exe");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsTrue(assembly.NamespaceList.ContainsKey("TestProject"));
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList.Count, 4);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[0].FieldList.Count, 1);  
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[0].PropertyList.Count, 1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[1].FieldList.Count, 2);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.IsTrue(assembly.NamespaceList["TestProject"].TypeList[2].MethodList[0].IsPublic);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["MyTest"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["MyTest"].TypeList[0].PropertyList[0].PropertyType, typeof(int));
        }
    }
}
