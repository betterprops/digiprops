using AutoMapper;
using PropertyManagementTool.Models;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mapper = AutoMapper.Mapper;

namespace PropertyManagementTool
{
    public static class Extensions
    {
        public static PropertyModel ToServiceModel(this PropertyViewModel model)
        {
            return Mapper.Map<PropertyViewModel, PropertyModel>(model);
        }

        public static PropertyEditViewModel ToEditViewModel(this PropertyModel model)
        {
            return Mapper.Map<PropertyModel, PropertyEditViewModel>(model);
        }

        public static OwnerViewModel ToViewModel(this OwnerModel model)
        {
            return Mapper.Map<OwnerModel, OwnerViewModel>(model);
        }

        public static OwnerEditViewModel ToEditViewModel(this OwnerModel model)
        {
            return Mapper.Map<OwnerModel, OwnerEditViewModel>(model);
        }

        public static LeaseTermViewModel ToViewModel(this LeaseTermModelExtended model)
        {
            return Mapper.Map<LeaseTermModelExtended, LeaseTermViewModel>(model);
        }

        public static LeaseTermViewModel ToViewModel(this LeaseTermModel model)
        {
            return Mapper.Map<LeaseTermModel, LeaseTermViewModel>(model);
        }

        public static IEnumerable<LeaseTermViewModel> ToViewModels(this IEnumerable<LeaseTermModel> model)
        {
            foreach (var term in model)
                yield return term.ToViewModel();
        }

        public static LeaseApplicationViewModel ToViewModel(this LeaseApplicationModel model)
        {
            return Mapper.Map<LeaseApplicationModel, LeaseApplicationViewModel>(model);
        }

        public static LeaseViewModel ToViewModel(this LeaseModel model)
        {
            return Mapper.Map<LeaseModel, LeaseViewModel>(model);
        }

        public static IEnumerable<LeaseViewModel> ToViewModels(this IEnumerable<LeaseModel> models)
        {
            foreach (var model in models)
            {
                yield return model.ToViewModel();
            }
        }

        public static LeaseModel ToServiceModel(this LeaseCreateViewModel model)
        {
            return Mapper.Map<LeaseCreateViewModel, LeaseModel>(model);
        }

        public static TransactionModel ToServiceModel(this TransactionViewModel model)
        {
            return Mapper.Map<TransactionViewModel, TransactionModel>(model);
        }
    }
}