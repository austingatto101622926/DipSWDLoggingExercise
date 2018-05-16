using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Factorialiser.Classes;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException
                if (String.IsNullOrWhiteSpace(textBoxInput.Text)) throw new NullValueException();
                //declare a variable here called input or datatype int
                int input;
                try
                {
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    input = int.Parse(textBoxInput.Text);
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                    logger.Debug("MainForm.buttonCalculate_Click: input successfully parsed");
                }
                catch
                {
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    logger.Debug("MainForm.buttonCalculate_Click: input parse failed");
                    // throw a NotIntegerException
                    throw new NotIntegerException(textBoxInput.Text);
                }
                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                int factorial = Calculator.Factorial(input);
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                logger.Debug("MainForm.buttonCalculate_Click: Calculate.Factorial suceeded");
                // change the text of labelOutput to reflect
                labelOutput.Content = factorial;
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"
                logger.Debug("MainForm.buttonCalculate_Click: labelOutput successfully updated");
            }
            catch (NullValueException)
            {
                // clear the labelOutput text and the textboxInput.Text
                textBoxInput.Text = "";
                labelOutput.Content = "";
                // present a message box saying ("Nothing Entered - Please enter an integer")
                MessageBox.Show("Nothing Entered - Please enter an integer");
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                logger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");
            }
            // ###########
            // add additional catches here, one for each of your custom exception types, in each one
            // clear the labelOutput text and the textboxInput.Text
            // display an approprate message box message and log the event as an Error level
            // using the same format as used in the NullValueException catch
            // ##########
            catch (NumberTooHighException)
            {
                textBoxInput.Text = "";
                labelOutput.Content = "";
                MessageBox.Show("Number Too High - Please enter an integer lower than 31");
                logger.Error("MainForm.buttonCalculate_Click: NumberTooHighException message displayed");
            }
            catch (NumberTooLowException)
            {
                textBoxInput.Text = "";
                labelOutput.Content = "";
                MessageBox.Show("Number Too low - Please enter an integer Higher than 0");
                logger.Error("MainForm.buttonCalculate_Click: NumberTooLowException message displayed");
            }
            catch (Exception ex)
            {
                // clear the labelOutput text and the textboxInput.Text
                textBoxInput.Text = "";
                labelOutput.Content = "";
                // present a message box saying ("Unknown Error")
                MessageBox.Show("Unknown Error");
                // log the event as an Fatal Level log
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)
                logger.Fatal($"MainForm.buttonCalculate_Click: Unknown Error: {ex.Message}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logger.Trace("Main Window Loaded");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            logger.Trace("Main Window Closed");
        }
    }
}
