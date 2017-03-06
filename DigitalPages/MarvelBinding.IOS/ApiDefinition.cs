using System;


namespace MarvelBindingIOS
{
    public class MarvelWS
    {
        public String[] ListaPersonagens()
        {

            String[] Personagens = new String[3];
            Personagens[0] = "Wolverine";
            Personagens[1] = "Rogue";
            Personagens[2] = "Iron Man";

            return Personagens;
        }

        public String[] ListaFasciculos()
        {

            String[] Fasciculos = new String[3];
            Fasciculos[0] = "Fasciculo 1";
            Fasciculos[1] = "Fasciculo 1";
            Fasciculos[2] = "Fasciculo 2";

            return Fasciculos;
        }

        public Detalhe DetalhePersonagem(String nome)
        {
            Detalhe personagem = new Detalhe();

            personagem.personagem = nome;
            personagem.Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a nisl dictum, posuere arcu eget, bibendum quam. Pellentesque at tempor lorem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce ut justo quam. Praesent aliquam lacus eu consequat vehicula. Aliquam malesuada nulla at vestibulum blandit. Vivamus pulvinar lectus eu volutpat tempor. Donec vel metus nec ligula molestie ullamcorper. ";

            return personagem;
        }
    }
    public class Detalhe
    {


        public String personagem
        {
            get; set;


        }




        public String Descricao
        {
            get; set;
        }

        public String getImg()
        {
            return personagem + ".jpg";
        }


    }
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //
}

