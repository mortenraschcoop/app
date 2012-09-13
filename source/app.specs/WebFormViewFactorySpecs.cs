using System.Web;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormViewFactory))]
  public class WebFormViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateWebFormViews,
                                      WebFormViewFactory>
    {
    }

    public class when_creating_a_view_for_data : concern
    {
      Establish c = () =>
      {
        web_form_path_registry = depends.on<IFindPathsToWebForms>();
        the_path = "blah.aspx";
        item = new AnItem();
        view = fake.an<IDisplayA<AnItem>>();
        depends.on<CreatePage_Behaviour>((path,type) =>
        {
          path.ShouldEqual(the_path);
          type.ShouldEqual(typeof(IDisplayA<AnItem>));
          return view;
        });

        web_form_path_registry.setup(x => x.get_the_path_to_view_for<AnItem>()).Return(the_path);
      };

      Because b = () =>
        result = sut.create_view_to_display(item);

      It should_find_the_path_to_the_view_that_can_display_the_information = () =>
        web_form_path_registry.received(x => x.get_the_path_to_view_for<AnItem>());

      It should_update_the_view_with_its_data = () =>
        view.report_model.ShouldEqual(item);
        
      It should_return_the_created_view = () =>
        result.ShouldEqual(view);
        
      static IFindPathsToWebForms web_form_path_registry;
      static AnItem item;
      static string the_path;
      static IDisplayA<AnItem> view;
      static IHttpHandler result;
    }

    public class AnItem
    {
    }
  }
}