using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notebook
{
    class Program
    {
        public static int TRYPARS()
        {
            
            int pars;
            while (!int.TryParse(Console.ReadLine(), out pars)) 
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Editor_notebook.ClearCurrentConsoleLine();
                Console.Write("Ошибка ввода! Введите заново: ");
            }
            
            return pars;
        }
     static void Main(string[] args)
        {
            int menu = 0, item;
            while(true){
                switch (menu) 
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("1.Новая запись \n2.Редактирование записи \n3.Удаление записи \n4.Показать все записи \n5.Выход");
                        menu = TRYPARS();
                        break;
                    case 1:
                        Console.Clear();
                        Editor_notebook.Create_Note();
                        Console.ReadKey();
                        menu = 0;
                        break;
                    case 2:
                        Console.Clear();
                        Editor_notebook.Show_Note();
                        Console.Write("Выберите номер записи, которую хотите отредактировать: ");
                        item = TRYPARS(); 
                        Editor_notebook.Show_single_Note(item - 1);
                        int sub_item = TRYPARS();
                        if (sub_item <= 9 && sub_item >= 1 && Editor_notebook.notelist.Count > 0)
                        {
                            Editor_notebook.Edit_Note(Editor_notebook.notelist[item - 1], sub_item);
                            Console.ReadKey();
                            menu = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Данного элемента не существует");
                            Console.ReadKey();
                            menu = 0;
                            break;
                        }
                    case 3:
                        Console.Clear();
                        Editor_notebook.Show_Note();
                        Console.Write("Выберите номер записи, которую хотите удалить: ");
                        item = TRYPARS();
                        if (Editor_notebook.notelist.Count < item)
                        {
                            Console.WriteLine("Данного элемента не существует");
                            Console.ReadKey();
                            menu = 0;
                            break;
                        }
                        Editor_notebook.Delete_Note(item-1);
                        Console.ReadKey();
                        menu = 0;
                        break;
                    case 4:
                        if (Editor_notebook.notelist.Count < 1)
                        {
                            Console.WriteLine("Записи отсутствуют.");
                            menu = 0;
                            Console.ReadKey();
                            break;
                        }
                        Console.Clear();
                        Editor_notebook.Show_Note();
                        Console.ReadKey();
                        menu = 0;
                        break; 
                    case 5:
                        return;
                }
            }
        }
     
    }

    public struct Note
    {
        public Note (string name)
        {
            this.name = string.Empty;
            this.lastname = string.Empty;
            this.number = string.Empty;
            this.country = string.Empty;
            this.otname = string.Empty;
            this.date = string.Empty;
            this.org = string.Empty;
            this.pozichion = string.Empty;
            this.other_notes = string.Empty;
        }
        public Note (string name, string lastname, string number, string country, string otname, string date, string org, string pozichion, string other_notes)
        {
            this.name = name;
            this.lastname = lastname;
            this.country = country;
            this.number = number;
            this.otname = otname;
            this.date = date;
            this.org = org;
            this.pozichion = pozichion;
            this.other_notes = other_notes;

        }
        public string name;
        public string lastname;
        public string country;
        public string number;
        public string otname;
        public string date;
        public string org;
        public string pozichion;
        public string other_notes;
    }

    class Editor_notebook
    {
        public static List<Note> notelist = new List<Note>();
        static string name;
        static string lastname;
        static string country;
        static string number;
        static string otname;
        static string date;
        static string org;
        static string pozichion;
        static string other_notes;
        public static void Create_Note()
        {
            name = CreateNotNULL("имя*");
            lastname = CreateNotNULL("фамилию*");
            number = CreateNotNULL("номер телефона*");
            country = CreateNotNULL("страну*");
            Console.Write("Введите отчество:");
            otname = Console.ReadLine();
            Console.Write("Введите дату рождения:");
            date = Console.ReadLine();
            Console.Write("Введите организацию:");
            org = Console.ReadLine();
            Console.Write("Введите должность:");
            pozichion = Console.ReadLine();
            Console.Write("Введите другую информацию:");
            other_notes = Console.ReadLine();
            notelist.Add(new Note(name, lastname, number, country, otname, date, org, pozichion, other_notes));
            Console.WriteLine("Новая запись добавлена!");
        }
        public static string CreateNotNULL(string text)
        {
            string text_notEmpty = string.Empty;
            Console.Write("Введите " + text + ":");
            text_notEmpty = Console.ReadLine();
            while (text_notEmpty == string.Empty) 
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.Write("Поля со звездочками являются обязательными! ");
                Console.Write("Введите "+ text +":");
                text_notEmpty = Console.ReadLine();
            }
            return text_notEmpty;
        }
        public static Note Find(string name, string lastname)
        {
            for (int i = 0; i<notelist.Count; i++)
            {
                if ((notelist[i].name == name||notelist[i].lastname == lastname)||(notelist[i].name == name && notelist[i].lastname == lastname))
                {
                    return notelist[i];
                }
            }
            Console.Write("Запись не найдена!");
            return new Note();
        }

        public static void Delete_Note(int item)
        {
            notelist.Remove(notelist[item]);
            Console.WriteLine("Запись №"+(item+1)+" удалена");
        }
        public static void Edit_Note(Note note, int row)
        {
            string newitem;
            notelist.Remove(note);
            switch (row)
            {
                case 1:
                    Console.Write("Введите новое имя:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(newitem, note.lastname, note.number, note.country, note.otname, note.date, note.org, note.pozichion, note.other_notes));
                    break;
                case 2:
                    Console.Write("Введите новую фамилию:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, newitem, note.number, note.country, note.otname, note.date, note.org, note.pozichion, note.other_notes));
                    break;
                case 3:
                    Console.Write("Введите новый номер:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, newitem, note.country, note.otname, note.date, note.org, note.pozichion, note.other_notes));
                    break;
                case 4:
                    Console.Write("Введите новую страну:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, newitem, note.otname, note.date, note.org, note.pozichion, note.other_notes));
                    break;
                case 5:
                    Console.Write("Введите новое отчество:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, note.country, newitem, note.date, note.org, note.pozichion, note.other_notes));
                    break;
                case 6:
                    Console.Write("Введите новую дату рождения:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, note.country, note.otname, newitem, note.org, note.pozichion, note.other_notes));
                    break;
                case 7:
                    Console.Write("Введите новую организацию:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, note.country, note.otname, note.date, newitem, note.pozichion, note.other_notes));
                    break;
                case 8:
                    Console.Write("Введите новую должность:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, note.country, note.otname, note.date, note.org, newitem, note.other_notes));
                    break;
                case 9:
                    Console.Write("Введите новую прочую запись:");
                    newitem = Console.ReadLine();
                    notelist.Add(new Note(note.name, note.lastname, note.number, note.country, note.otname, note.date, note.org, note.pozichion, newitem));
                    break;

            }
        }
        public static void Show_Note()
        {
            for (int i = 0; i < notelist.Count; i++)
            {
                Console.WriteLine((i+1).ToString()+". "+notelist[i].name+" "+notelist[i].lastname +" "+ notelist[i].number);
                Console.WriteLine("___________________________________________________________________________________________");
            }
        }
        public static void Show_single_Note(int item)
        {
            if (notelist.Count == 0) Console.WriteLine("Список пуст.");
            else
            {
                Console.Clear();
                Console.WriteLine("1. " + notelist[item].name);
                Console.WriteLine("2. " + notelist[item].lastname);
                Console.WriteLine("3. " + notelist[item].number);
                Console.WriteLine("4. " + notelist[item].country);
                Console.WriteLine("5. " + notelist[item].otname);
                Console.WriteLine("6. " + notelist[item].date);
                Console.WriteLine("7. " + notelist[item].org);
                Console.WriteLine("8. " + notelist[item].pozichion);
                Console.WriteLine("9. " + notelist[item].other_notes);
                Console.Write("Введите номер поля которое необходимо отредактировать: ");
            }
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }

}
