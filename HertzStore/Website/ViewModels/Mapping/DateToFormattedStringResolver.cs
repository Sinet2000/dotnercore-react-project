using AutoMapper;
using BusinessLogic.Helpers;
using System;

namespace Website.ViewModels.Mapping
{
    public class DateToFormattedStringResolver : IMemberValueResolver<object, object, DateTime?, string>
    {
        public string Resolve(object source, object destination, DateTime? sourceMember, string destMember, ResolutionContext context)
        {
            if (!sourceMember.HasValue)
                return "";

            return sourceMember.Value.ToString(Constants.DateFormat);
        }
    }
}
