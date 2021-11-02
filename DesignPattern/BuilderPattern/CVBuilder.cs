using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class CVBuilder
    {
        private CV _cv;

        public CVBuilder()
        {
            _cv = new CV();
            _cv.Skills = new List<string>();
        }

        public CVBuilder AddName(string name)
        {
            _cv.Name = name;
            return this;
        }

        public CVBuilder AddAddress(string address)
        {
            _cv.Address = address;
            return this;
        }

        public CVBuilder AddPhoneNo(Int64 phoneNo)
        {
            _cv.PhoneNo = phoneNo;
            return this;
        }

        public CVBuilder AddSkill(string skill)
        {
            _cv.Skills.Add(skill);
            return this;
        }
        
        public CV GetCV()
        {
            return _cv;
        }
    }
}
