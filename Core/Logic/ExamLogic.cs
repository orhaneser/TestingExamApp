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
  public  class ExamLogic
    {
        public ResultHelper AddExam(ExamDto examDto)
        {
            try
            {
                Exam item = new Exam();
                item.ExamID = examDto.ExamID;
                item.Exam1 = examDto.Exam;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Exam>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.ExamID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetExam(ExamDto examDto)
        {
            try
            {
                Exam item = new Exam();
                item.ExamID = examDto.ExamID;
                item.Exam1 = examDto.Exam;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Exam>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.ExamID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, examDto.ExamID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelExam(int ExamID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<Exam>().GetById(x => x.ExamID == ExamID);
                    unitofWork.GetRepository<Exam>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.ExamID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, ExamID, ResultHelper.UnSuccessMessage);

            }
        }
        public ExamDto GetExam(int ExamID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    Exam item = new Exam();
                    item = unitofWork.GetRepository<Exam>().GetById(x => x.ExamID == ExamID);
                    ExamDto examDto = new ExamDto();
                    examDto.ExamID = item.ExamID;
                    examDto.Exam = item.Exam1;

                    return examDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExamDto> GetAllExam()
        {
            try
            {
                List<ExamDto> list = new List<ExamDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<Exam> collection = unitofWork.GetRepository<Exam>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        ExamDto examDto = new ExamDto();
                        examDto.ExamID = item.ExamID;
                        examDto.Exam = item.Exam1;
                        list.Add(examDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<ExamDto>();
            }
        }


    }
}
