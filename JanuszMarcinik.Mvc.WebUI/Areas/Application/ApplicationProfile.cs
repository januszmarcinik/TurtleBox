﻿using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Application
{
    public class ApplicationProfile : Profile
    {
        #region ProfileName
        public override string ProfileName
        {
            get { return this.GetType().FullName; }
        }
        #endregion

        #region ApplicationProfile()
        public ApplicationProfile()
        {

        }
        #endregion
    }
}