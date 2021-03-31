using FrameworkWorkShop.Core.Aspects.PostSharp;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValıdatıon;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService  
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }
        

        [FluentValidationAspect(typeof(MemberValıdator))]
        public void Add(Member member)
        {

            CheckIfMemberExsts(member);
            CheckIfUserValidFromKps(member);

            _memberDal.Add(member);
        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValideteUSer(member) == false)
            {
                throw new Exception("Kullanici dogrulamasi gecekli degil.");
            }
        }

        private void CheckIfMemberExsts(Member member)
        {
            if (_memberDal.SingleOrDefault(t => t.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu Kullanicidaha once kayit olmustur.");
            }
        }
    }
}
