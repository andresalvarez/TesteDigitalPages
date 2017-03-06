using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalPages.Views
{
  
    public class CustomCell : ViewCell
      {
         public CustomCell()
            {
                //instantiate each of our views
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
       
            Label left = new Label();                

                
            left.SetBinding(Label.TextProperty, ".");
            image.Source = "arrow.png";
            left.VerticalTextAlignment = TextAlignment.Center;
         
            image.VerticalOptions = LayoutOptions.Center;
            image.HorizontalOptions = LayoutOptions.EndAndExpand;

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.White;

            cellWrapper.Orientation = StackOrientation.Horizontal;

            left.TextColor = Color.Black;




            cellWrapper.Children.Add(left);
            cellWrapper.Children.Add(image);
            cellWrapper.Orientation = StackOrientation.Horizontal;
         //   cellWrapper.VerticalOptions = LayoutOptions.Center;       
            View = cellWrapper;
        }
        }
    }
