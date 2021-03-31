using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistrration.ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMemberService _memberService = InstanceFactory.GetInstance<IMemberService>();
            _memberService.Add(new Member()
            {
                FirstName ="Mustafa",
                Email = "test@gmail.com",
                LastName ="YILDIRIM",
                DateOfBirth =new DateTime(1993,6,24),
                TcNo = "12345678912"
            });

            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
