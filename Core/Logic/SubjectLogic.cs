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
   public class SubjectLogic
    {
        public ResultHelper AddSubject(SubjectDto subjectDto)
        {
            try
            {
                Subject item = new Subject();
                item.SubjectID = subjectDto.SubjectID;
                item.SubjectText = subjectDto.SubjectText;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Subject>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.SubjectID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetSubject(SubjectDto subjectDto)
        {
            try
            {
                Subject item = new Subject();
                item.SubjectID = subjectDto.SubjectID;
                item.SubjectText = subjectDto.SubjectText;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Subject>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.SubjectID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, subjectDto.SubjectID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelSubject(int SubjectID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<Subject>().GetById(x => x.SubjectID == SubjectID);
                    unitofWork.GetRepository<Subject>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.SubjectID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, SubjectID, ResultHelper.UnSuccessMessage);

            }
        }
        public SubjectDto GetSubject(int SubjectID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    Subject item = new Subject();
                    item = unitofWork.GetRepository<Subject>().GetById(x => x.SubjectID == SubjectID);
                    SubjectDto subjectDto = new SubjectDto();
                    subjectDto.SubjectID = item.SubjectID;
                    subjectDto.SubjectText = item.SubjectText;

                    return subjectDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SubjectDto> GetAllSubject()
        {
            try
            {
                List<SubjectDto> list = new List<SubjectDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<Subject> collection = unitofWork.GetRepository<Subject>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        SubjectDto subjectDto = new SubjectDto();
                        subjectDto.SubjectID = item.SubjectID;
                        subjectDto.SubjectText = item.SubjectText;
                        list.Add(subjectDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SubjectDto>();
            }
        }

    }
}
