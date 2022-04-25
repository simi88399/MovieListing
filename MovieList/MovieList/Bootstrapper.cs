using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MovieList.Implementaion.Repository;
using MovieList.Interfaces;
using Unity.Mvc4;

namespace MovieList
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();
            container.RegisterType<IMovieListRepo, MovieListRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}