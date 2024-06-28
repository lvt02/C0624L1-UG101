using System.Text;
namespace Lession04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // Console.WriteLine("Nhập chiều cao đơn vị m:");
            // var chieuCao = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Nhập cân nặng đơn vị Kg:");
            // var canNang = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine($"BMI = {canNang / (chieuCao * chieuCao)}");
            
            // Console.WriteLine("Nhập number_1:");
            // int nb1 = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Nhập number_2:");
            // int nb2 = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Nhập number_3:");
            // int nb3 = Convert.ToInt32(Console.ReadLine());
            // int max = nb1;
            // if (nb2 > max )
            // {
            //     max = nb2;
            //     if(nb3 > max)
            //     {
            //         Console.WriteLine($"Số lớn nhất là: {nb3}");
            //     }
            //     else
            //     {
            //         Console.WriteLine($"Số lớn nhất là: {max}");
            //     }
            // }   
            // else 
            // {
            //     if(nb3 > max)
            //     {
            //         Console.WriteLine($"Số lớn nhất là: {nb3}");
            //     }
            //     else
            //     {
            //         Console.WriteLine($"Số lớn nhất là: {max}");
            //     }
            // }

            Console.WriteLine("Nhập cân nặng (Kg):");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhập chiều cao (m):");
            double height = Convert.ToDouble(Console.ReadLine());
            double BMI = weight / ( height * height );
            Console.WriteLine($"Chỉ cố BMI: {BMI}");
            if(BMI < 18.5)
            {
                Console.WriteLine("Tình trạng cơ thể: Gầy");
            }else if(BMI >= 18 && BMI < 24.9)
            {
                Console.WriteLine("Tình trạng cơ thể: Bình thường");
            }else if(BMI >= 25 && BMI < 29.9)
            {
                Console.WriteLine("Tình trạng cơ thể: Tăng cân");
            }else if(BMI >= 30 && BMI < 34.9)
            {
                Console.WriteLine("Tình trạng cơ thể: Béo phì độ 1");
            }else if(BMI >= 35 && BMI < 39.9)
            {
                Console.WriteLine("Tình trạng cơ thể: Béo phì độ 2");
            }else
            {
                Console.WriteLine("Tình trạng cơ thể: Béo phì độ 3");
            }
        }
    }
}


