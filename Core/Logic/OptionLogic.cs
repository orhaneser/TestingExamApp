using Core.Helper;
using Examp.Database;
using Examp.Dto;
using LocationApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
   public class OptionLogic
    {
        public ResultHelper AddOption(OptionDto optionDto)
        {
            try
            {
                Option item = new Option();
                item.OptionID = optionDto.OptionID;
                item.OptionA = optionDto.OptionA;
                item.OptionB = optionDto.OptionB;
                item.OptionC = optionDto.OptionC;
                item.OptionD = optionDto.OptionD;
                item.OptionE = optionDto.OptionE;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Option>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.OptionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetOption(OptionDto optionDto)
        {
            try
            {
                Option item = new Option();
                item.OptionID = optionDto.OptionID;
                item.OptionA = optionDto.OptionA;
                item.OptionB = optionDto.OptionB;
                item.OptionC = optionDto.OptionC;
                item.OptionD = optionDto.OptionD;
                item.OptionE = optionDto.OptionE;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Option>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.OptionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, optionDto.OptionID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelOption(int OptionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<Option>().GetById(x => x.OptionID == OptionID);
                    unitofWork.GetRepository<Option>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.OptionID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, OptionID, ResultHelper.UnSuccessMessage);

            }
        }
        public OptionDto GetOption(int OptionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    Option item = new Option();
                    item = unitofWork.GetRepository<Option>().GetById(x => x.OptionID == OptionID);
                    OptionDto optionDto = new OptionDto();
                    optionDto.OptionID = item.OptionID;
                    item.OptionA = optionDto.OptionA;
                    item.OptionB = optionDto.OptionB;
                    item.OptionC = optionDto.OptionC;
                    item.OptionD = optionDto.OptionD;
                    item.OptionE = optionDto.OptionE;
                    return optionDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<OptionDto> GetAllOption()
        {
            try
            {
                List<OptionDto> list = new List<OptionDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<Option> collection = unitofWork.GetRepository<Option>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        OptionDto optionDto = new OptionDto();
                        optionDto.OptionID = item.OptionID;
                        optionDto.OptionA = item.OptionA;
                        optionDto.OptionB = item.OptionB;
                        optionDto.OptionC = item.OptionC;
                        optionDto.OptionD = item.OptionD;
                        optionDto.OptionE = item.OptionE;

                        list.Add(optionDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<OptionDto>();
            }
        }

    }
}
