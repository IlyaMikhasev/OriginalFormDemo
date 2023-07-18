using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriginalFormDemo
{
    internal class OrigWindow
    {
        public static Region myRegion;
        static public void setOriginalButton(Button but,Size sizeF, string _form = "normal") {

            System.Drawing.Drawing2D.GraphicsPath myPathButt = new System.Drawing.Drawing2D.GraphicsPath();
            if (_form == "polygon")
            {
                // Выключаем элементы управления формой
                but.BackColor = Color.White;
                // Формируем вершины
                /* Point[] myPoint = { new Point(0,0),
                 new Point(form.Width, 0),
                 new Point(form.Width-50, form.Height),
                 new Point(50, form.Height)};*/
                myPathButt.AddPolygon(new Point[] { new Point(but.Size.Height, 0), 
                                                new Point(but.Size.Width/2, 0), 
                                                new Point(but.Size.Width/2+but.Size.Height, but.Size.Height/3),
                                                new Point(but.Size.Width/2+but.Size.Height, but.Size.Height-but.Size.Height/3),
                                                new Point(but.Size.Width/2, but.Size.Height),
                                                new Point(but.Size.Height, but.Size.Height),
                                                new Point(0, but.Size.Height-but.Size.Height/3),
                                                new Point(0, but.Size.Height/3) }); 
                //myPath.AddEllipse(0, 0, form.Width, form.Height);
                /*myPath.AddPolygon(myPoint);*/
                // Устанавливаем видимую область                           
                myRegion = new Region(myPathButt);
                but.Region = myRegion;
            }
            else
            {
                if (_form == "ellipse")
                {
                    // Выключаем элементы управления формой
                    but.BackColor = Color.White;
                    // Эллипс с высотой и шириной формы
                    myPathButt.AddEllipse(24, 0, but.Width/3, but.Height);
                    // Устанавливаем видимую область                           
                    myRegion = new Region(myPathButt);
                   but.Region = myRegion;

                }
                else
                {                   
                   
                    myPathButt.AddPolygon(new Point[] { new Point(0, 0), 
                                                new Point(but.Size.Width, 0),
                                                new Point(but.Size.Width, but.Size.Height),
                                                new Point(0, but.Size.Height) });
                    myRegion = new Region(myPathButt);
                    but.Region= myRegion;
                }
            }
        }
        static public void setOriginalForm(Form form, string _form = "normal")
        {
            // Создаём форму границ - объект GraphicsPath
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            if (_form == "polygon")
            {
                // Выключаем элементы управления формой
                form.FormBorderStyle = FormBorderStyle.None;
                form.BackColor = Color.Orange;
                // Формируем вершины
                /* Point[] myPoint = { new Point(0,0),
                 new Point(form.Width, 0),
                 new Point(form.Width-50, form.Height),
                 new Point(50, form.Height)};*/
                myPath.AddPolygon(new Point[] { new Point(form.Width/4, 0), //Верхняя левая точка
                                                new Point(form.Width-form.Width/4, 0), //Верхняя правая точка
                                                new Point(form.Width, form.Height/4),
                                                new Point(form.Width, form.Height-form.Height/4),
                                                new Point(form.Width-form.Width/4, form.Height),
                                                new Point(form.Width/4, form.Height),
                                                new Point(0, form.Height-form.Height/4),//Нижняя левая точка
                                                new Point(0, form.Height/4) }); //Нижняя правая точка
                //myPath.AddEllipse(0, 0, form.Width, form.Height);
                /*myPath.AddPolygon(myPoint);*/
                // Устанавливаем видимую область                           
                myRegion = new Region(myPath);
                form.Region = myRegion;
            }
            else
            {
                if (_form == "ellipse")
                {
                    // Выключаем элементы управления формой
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackColor = Color.Orange;
                    // Эллипс с высотой и шириной формы
                    myPath.AddEllipse(0, 0, form.Width, form.Height);
                    // Устанавливаем видимую область                           
                    myRegion = new Region(myPath);
                    form.Region = myRegion;
                    
                }
                else
                {
                    form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    form.BackColor = Form.DefaultBackColor;
                }
            }
        }
    }
}
