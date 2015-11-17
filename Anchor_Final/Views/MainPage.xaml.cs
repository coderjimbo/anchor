using Anchor_Final.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;


namespace Anchor_Final.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
            insertTag("<!doctype html>\n<html>\n<head>\n\t<meta charset='utf-8'>\n\t<title>Untitled Document</title>\n</head>\n\n<body>\n\n</body>\n</html>", true);

            InkDrawingAttributes drawingAttributes = inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

            drawingAttributes.Color = Windows.UI.Color.FromArgb(255, 255, 255, 255);
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
            inkCanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        
 
        // strongly-typed view models enable x:bind
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
        bool inkisVisible = false;

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("h1");
            focusOnCanvas();
        }
        private void focusOnCanvas()
        {
            if (EditCanvas.FocusState == Windows.UI.Xaml.FocusState.Unfocused)
            {
                EditCanvas.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }
        private void insertTag(String tagStart, String tagEnd)
        {
            string text;
            EditCanvas.Document.Selection.GetText(0, out text);
            if (text != "")
            {
                EditCanvas.Document.Selection.SetText(0, "<" + tagStart + ">" + text + tagEnd);
            }
            else
            {
                EditCanvas.Document.Selection.SetText(0, "<" + tagStart + ">" + tagEnd);
            }
        }
        private void insertTag(String tag)
        {
            string text;
            EditCanvas.Document.Selection.GetText(0, out text);
            if (text != "")
            {
                EditCanvas.Document.Selection.SetText(0, "<" + tag + ">" + text + "</" + tag + ">");
            }
            else
            {

                EditCanvas.Document.Selection.SetText(0, "<" + tag + "></" + tag + ">");
                EditCanvas.Document.Selection.SetRange(EditCanvas.Document.Selection.StartPosition + 2 + tag.Length, EditCanvas.Document.Selection.StartPosition + 2 + tag.Length);
            }
        }

        private void insertTag(String text, bool manual)
        {
            if(manual)
            {
                EditCanvas.Document.Selection.SetText(0, text);
            }
        }

        private void countLines(List<List<int>> lineList)
        {
            string documentText;
            int lineCount = 0;
            int lastLineEndIndex = 0;

            EditCanvas.Document.GetText(0, out documentText);
            if (documentText.Length >= 2)
            {
                for (int i = 0; i < (documentText.Length - 2); i++)
                {
                    if (documentText.Substring(i, 1) == "\r")
                    {
                        lineList.Add(new List<int> {i, lineCount, lastLineEndIndex});
                        lastLineEndIndex = i;
                    }
                    else if (documentText.Substring(i, 1) == "\r\n")
                    {
                        lineList.Add(new List<int> { i, lineCount, lastLineEndIndex});
                        lastLineEndIndex = i;
                    }
                }
            }
        }

        public void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        public void addButtons(List<List<int>> buttonList, int indexToAddFrom)
        {
            
        }

        private void EditCanvas_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Tab)
            {
                e.Handled = true;
                tabSelection();
            }
        }

        private void tabSelection()
        {
            String testString;
            EditCanvas.Document.Selection.GetText(0, out testString);

            if (testString != "")
            {
                EditCanvas.Document.Selection.SetText(0, "\t" + testString);
            }
            else
            {
                EditCanvas.Document.Selection.SetText(0, "\t");
                EditCanvas.Document.Selection.StartPosition = EditCanvas.Document.Selection.EndPosition;
            }
        }

        private void EditCanvas_TextChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        private void EditCanvas_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            
        }

        private void button_tab_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            tabSelection();
            focusOnCanvas();
        }

        private void Button_Undo_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EditCanvas.Document.Undo();
        }

        private void Button_Redo_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EditCanvas.Document.Redo();
        }

        private void button_h2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("h2");
            focusOnCanvas();
        }

        private void button_h3_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("h3");
            focusOnCanvas();
        }

        private void button_p_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("p");
            focusOnCanvas();
        }

        private void button_center_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("center");
            focusOnCanvas();
        }

        private void button_strong_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("strong");
            focusOnCanvas();
        }

        private void button_table_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("table");
            focusOnCanvas();
        }

        private void button_th_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("th");
            focusOnCanvas();
        }

        private void button_tr_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("tr");
            focusOnCanvas();
        }

        private void button_td_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("td");
            focusOnCanvas();
        }

        private void button_ul_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("ul");
            focusOnCanvas();
        }

        private void button_ol_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("ol");
            focusOnCanvas();
        }

        private void button_li_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("li");
            focusOnCanvas();
        }

        private void button_div_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("div");
            focusOnCanvas();
        }

        private void button_span_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("span");
            focusOnCanvas();
        }

        private void button_header_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("header");
            focusOnCanvas();
        }

        private void button_footer_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("footer");
            focusOnCanvas();
        }

        private void button_section_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("section");
            focusOnCanvas();
        }

        private void button_quote_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("quote");
            focusOnCanvas();
        }

        private void button_article_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("article");
            focusOnCanvas();
        }

        private void button_img_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("img", "");
            focusOnCanvas();
        }

        private void button_video_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("video");
            focusOnCanvas();
        }

        private void button_canvas_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("canvas");
            focusOnCanvas();
        }

        private void button_javascript_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("script type='text/javascript'", "</script>");
            focusOnCanvas();
        }

        private void button_html_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("a");
            focusOnCanvas();
        }

        public async void Button_Open_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".htm");
            picker.FileTypeFilter.Add(".html");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                String fileText = await Windows.Storage.FileIO.ReadTextAsync(file);
                // Application now has read/write access to the picked file
                this.EditCanvas.Document.SetText(0, fileText);
            }
        }

        public async void Button_Save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();

            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.Desktop;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Hypertext Markup Language (HTML)", new List<string>() { ".htm" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "index";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                String editorContents ="";
                EditCanvas.Document.GetText(0, out editorContents);

                await Windows.Storage.FileIO.WriteTextAsync(file, editorContents);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    
                }
                else
                {
                    this.EditCanvas.Document.SetText(0, "Sorry. Your file " + file.Name + " couldn't be saved.");
                }
            }
        }

        private void Button_Refresh_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string webText = "Please Reload Design View";
            EditCanvas.Document.GetText(0, out webText);
            webDesignView.NavigateToString(webText);
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string webText = "Please Reload Design View";
            EditCanvas.Document.GetText(0, out webText);
            webDesignView.NavigateToString(webText);
        }

        private void button_toggle_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(inkisVisible == true)
            {
                button_toggle.Content = "Start Inking";
                inkCanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                inkisVisible = false;
            }
            else
            {
                button_toggle.Content = "Stop Inking";
                inkCanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                inkisVisible = true;
            }
            
        }

        private void button_clear_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        private void button_php_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("<?php ?>", true);
        }

        private void button_style_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            insertTag("<style>\n\t\tbody {\n\t\t\tbackground-color: #ffffff;\n\t\t\tcolor: #000000;\n\t\t}\n\t</style>", true);
        }
    }
}
