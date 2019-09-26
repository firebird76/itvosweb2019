using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcUI.Controllers;
using System.Collections.Generic;
using WorldLib;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      Assert.IsTrue(true, "Weltuntergang");
    }

    [TestMethod]
    public async Task Test2()
    {
      var hc = new HomeController();
      Assert.IsTrue(hc.Index() is ViewResult);

      DbContextOptions<MondialContext> options;
      var builder = new DbContextOptionsBuilder<MondialContext>();
      builder.UseInMemoryDatabase("Mondial");
      options = builder.Options;



      using (MondialContext mondialContext = new MondialContext(options))
      {
        mondialContext.Continents.Add(new Continent { Name = "Lummerland", Area = 55 });
        mondialContext.Continents.Add(new Continent { Name = "Pangea", Area = 525252 });
        mondialContext.SaveChanges();

        World world = new World(mondialContext);
        var continents = await world.GetContinentsAsync();
        Assert.IsTrue(continents.Count() == 2);
        Assert.IsTrue(continents.First().Name == "Lummerland");


        WorldController worldController = new WorldController(world);
        var vr = (await worldController.Index()) as ViewResult;
        //Assert.IsInstanceOfType(view, typeof(ViewResult));
        Assert.IsNotNull(vr);
        var model = vr.Model as IEnumerable<Continent>;
        Assert.IsNotNull(model);
        Assert.IsTrue(model.Last().Name == "Pangea");
      }


    }
  }
}
