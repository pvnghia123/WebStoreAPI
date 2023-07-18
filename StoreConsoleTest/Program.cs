using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StoreConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var actor = new Actor();
            actor.name = "sdjfhsdkjfhsdk";
            actor.setABC();

            //ValidationContext context = new ValidationContext(actor, null, null);
            //// results - lưu danh sách ValidationResult, kết quả kiểm tra
            //List<ValidationResult> results = new List<ValidationResult>();
            //// thực hiện kiểm tra dữ liệu
            //bool valid = Validator.TryValidateObject(actor, context, results, true);

            //if (!valid)
            //{
            //    // Duyệt qua các lỗi và in ra
            //    foreach (ValidationResult vr in results)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //        Console.Write($"{vr.MemberNames.First(),13}");
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine($"    {vr.ErrorMessage}");
            //    }
            //}
            // Đọc Attribute của phương thức
            //foreach (var m in actor.GetType().GetMethods())
            //{
            //    foreach (Attribute attr in m.GetCustomAttributes(false))
            //    {
            //        MaxLengthAttribute mota = attr as MaxLengthAttribute;
            //        if (mota != null)
            //        {
            //            Console.WriteLine($"{m.Name,10} ");
            //        }
            //    }
            //}
        }


        //Console.WriteLine(actor.GetType().GetCustomAttributes(false).Length);
        //foreach (var attribute in actor.GetType().GetCustomAttributes(false))
        //{
        //    var length = attribute as MaxLengthAttribute;
        //    if(length != null)
        //    {
        //        if(attribute.GetType().Name.Length > 5)
        //        {

        //            Console.WriteLine("length > 5");
        //        } else
        //        {
        //            Console.WriteLine("length <= 5");
        //        }
        //    }
        //}
          // Đọc Attribute của phương thức
      
    }
}
