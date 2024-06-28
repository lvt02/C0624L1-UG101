using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
namespace Lession04
{
    class SwitchCase
    {
        /*
        Naming Convention
        F1: PascalCase => HoVaTen => namspace, class, method
        F2: camelCase => hoVaTen => varible
        F3: snake_case => ho_va_ten
        */
        // có 2 loại lỗi
        // 1. Syntax error
        // 2. Logic error
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            #region
            // Console.WriteLine("Enter month:");
            // //int month = Convert.ToInt32(Console.ReadLine());
            // int month = 4;
            // switch(month)
            // {
            //     case 1:
            //     case 3:
            //     case 5:
            //     case 7:
            //     case 8:
            //     case 10:
            //     case 12:
            //         Console.WriteLine("31 days");
            //         break;
            //     case 4:
            //     case 6:
            //     case 9:
            //     case 11:
            //         Console.WriteLine("31 days");
            //         break;
            //     case 2:
            //         Console.WriteLine("28 or 29 days");
            //         break;
            //     default:
            //         Console.WriteLine("You entered invalid month");
            //         Console.WriteLine("Please enter from 1 to 12");
            //         break;
            // }
            #endregion
            // Console.WriteLine("Enter day:");
            // int day = Convert.ToInt32(Console.ReadLine());
            // switch (day)
            // {
            //     case  1:
            //         Console.WriteLine("Thứ 2");
            //         break;
            //     case 2:
            //         Console.WriteLine("Thứ 3");
            //         break;
            //     case 3:
            //         Console.WriteLine("Thứ 4");
            //         break;
            //     case 4:
            //         Console.WriteLine("Thứ 5");
            //         break;
            //     case 5:
            //         Console.WriteLine("Thứ 6");
            //         break;
            //     case 6:
            //         Console.WriteLine("Thứ 7");
            //         break;
            //     case 7:
            //         Console.WriteLine("Chủ nhật");
            //         break;
            //     default:
            //         Console.WriteLine("You enter invalid day");
            //         Console.WriteLine("Please enter 1 to 7");
            //         break;
            // }




            // Console.WriteLine("Nhâp điểm trung bình môn học");
            // double diemTB = Convert.ToDouble(Console.ReadLine());
            // if (diemTB > 10 || diemTB < 0)
            // {
            //     Console.WriteLine("Invalid Score");
            // }
            // else
            // {
            //     if (diemTB >= 9 && diemTB <= 10)
            //     {
            //         Console.WriteLine("Học lực: Xuất sắc");
            //     }
            //     else if (diemTB >= 8 && diemTB < 9)
            //     {
            //         Console.WriteLine("Học lực: Giỏi");
            //     }
            //     else if (diemTB >= 7 && diemTB < 8)
            //     {
            //         Console.WriteLine("Học lực: Khá");
            //     }
            //     else if (diemTB >= 5 && diemTB < 7)
            //     {
            //         Console.WriteLine("Học lực: Trung bình");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Học lực: Yếu");
            //     }
            // }
            //double diemTB = 6;



            // switch (diemTB < 10 && diemTB > 9)
            // {
            //     case true:
            //         Console.WriteLine("Xuat sac");
            //         break;
            //     default:
            //         switch (diemTB > 9)
            //         {
            //             case true:
            //                 Console.WriteLine("gioi");
            //                 break;
            //             default:
            //                 switch (diemTB > 8)
            //                 {
            //                     case true:
            //                         Console.WriteLine("Kha");
            //                         break;
            //                     default:
            //                         switch (diemTB > 7)
            //                         {
            //                             case true:
            //                                 Console.WriteLine("Trung binh");
            //                                 break;
            //                             default:
            //                                 switch (diemTB > 5)
            //                                 {
            //                                     case true:
            //                                         Console.WriteLine("Yeu");
            //                                         break;
            //                                     default:
            //                                         Console.WriteLine("Yeu");
            //                                         break;
            //                                 }
            //                                 break;
            //                         }
            //                         break;
            //                 }
            //                 break;
            //         }
            //         break;
            // }


            // string firstName = "Binh";
            // bool gender = true;
            // bool married = true;
            // string result = gender ? $"Mr.{firstName}" : married ? $"Mrs. {firstName}" : $"Ms. {firstName}";
            // Console.WriteLine(result);

            Console.WriteLine("Nhập number 1:");
            int nb1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhập number 2:");
            int nb2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhập number 3:");
            int nb3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"So lon nhat la: {((nb1 > nb2 && nb1 > nb3) ? nb1 : (nb2 > nb1 && nb2 > nb3) ? nb2 : nb3)}");
        }
    }
}