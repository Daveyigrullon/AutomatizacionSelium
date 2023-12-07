using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatizacionSelium
{
    public class Program
    {
        static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.todolistme.net/");
            driver.Manage().Window.Maximize();

            try
            {
                IWebElement newTodoField = driver.FindElement(By.Id("newtodo"));

                newTodoField.SendKeys("Estudiar ingles");
                Thread.Sleep(1000);

                Actions action = new Actions(driver);
                action.SendKeys(Keys.Enter).Perform();

                Console.WriteLine("Tarea agregada exitosamente.");


                Thread.Sleep(2000);

                IWebElement lastTodoCheckbox = driver.FindElement(By.CssSelector("#mytodos li:last-child input[type='checkbox']"));
                lastTodoCheckbox.Click();


                Thread.Sleep(2000);


            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Elemento no encontrado: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }

            try
            {
                // Encontrar el primer elemento de la lista de tareas
                IWebElement firstTodo = driver.FindElement(By.CssSelector("#mytodos li:first-child span"));

                // Obtener el texto original de la tarea
                string originalText = firstTodo.Text;

                // Hacer doble clic en la tarea para activar la edición
                Actions action = new Actions(driver);
                action.DoubleClick(firstTodo).Perform();

                // Encontrar el campo de edición
                IWebElement editField = driver.FindElement(By.CssSelector("#mytodos li:first-child input[type='text']"));

                // Borrar el texto original y agregar uno nuevo
                editField.Clear();
                editField.SendKeys("Tengo que hacer tareas, texto editado");
                Thread.Sleep(3000);
                // Guardar los cambios presionando Enter
                editField.SendKeys(Keys.Enter);

                Console.WriteLine("Tarea editada exitosamente.");

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Elemento no encontrado: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }

            try
            {
                // Encontrar el icono de "x" del primer elemento de la lista
                IWebElement firstTodoDeleteIcon = driver.FindElement(By.CssSelector("#mytodos li:first-child .delete"));
                Thread.Sleep(3000);
                // Hacer clic en el icono de "x" para eliminar la primera tarea
                firstTodoDeleteIcon.Click();

                Console.WriteLine("Primera tarea eliminada exitosamente.");



                // Encontrar el checkbox de la última tarea y marcarlo como completado
                IWebElement lastTodoCheckbox = driver.FindElement(By.CssSelector("#mytodos li:last-child input[type='checkbox']"));
                lastTodoCheckbox.Click();
                Thread.Sleep(3000);
                // Localiza el último checkbox de la lista de tareas:




            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Elemento no encontrado: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }

        }
    }

}
