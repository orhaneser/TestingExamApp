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
  public class SubjectLessonLogic
    {
        public ResultHelper AddSubjectLesson(SubjectLessonDto subjectLessonDto)
        {
            try
            {
                SubjectLesson item = new SubjectLesson();
                item.SubjectLessonID = subjectLessonDto.SubjectLessonID;
                item.LessonID = subjectLessonDto.LessonID;
                item.SubjectID = subjectLessonDto.SubjectID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<SubjectLesson>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.SubjectLessonID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetSubjectLesson(SubjectLessonDto subjectLessonDto)
        {
            try
            {
                SubjectLesson item = new SubjectLesson();
                item.SubjectLessonID = subjectLessonDto.SubjectLessonID;
                item.LessonID = subjectLessonDto.LessonID;
                item.SubjectID = subjectLessonDto.SubjectID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<SubjectLesson>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.SubjectLessonID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelSubjectLesson(int subjectLessonID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected= unitofWork.GetRepository<SubjectLesson>().GetById(x => x.SubjectLessonID == subjectLessonID);
                    unitofWork.GetRepository<SubjectLesson>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, subjectLessonID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, subjectLessonID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public SubjectLessonDto GetSubjectLesson(int subjectLessonID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    SubjectLesson item = new SubjectLesson();
                    item = unitofWork.GetRepository<SubjectLesson>().GetById(x => x.SubjectLessonID == subjectLessonID);
                    SubjectLessonDto subjectLessonDto = new SubjectLessonDto();
                    subjectLessonDto.SubjectLessonID = item.SubjectLessonID;
                    subjectLessonDto.LessonID = (int)item.LessonID;
                    subjectLessonDto.SubjectID =(int) item.SubjectID;

                    return subjectLessonDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SubjectLessonDto> GetAllSubjectLesson()
        {
            try
            {
                List<SubjectLessonDto> list = new List<SubjectLessonDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from sl in unitofWork.GetRepository<SubjectLesson>().Select(null, null)
                                 join s in unitofWork.GetRepository<Subject>().Select(null, null) on sl.SubjectID equals s.SubjectID
                                 join l in unitofWork.GetRepository<Lesson>().Select(null, null) on sl.LessonID equals l.LessonID
                                 select new
                                 {
                                     SubjectLessonID= sl.SubjectLessonID,
                                     SubjectID = s.SubjectID,
                                     SubjectText = s.SubjectText,
                                     LessonID = l.LessonID,
                                     LessonText = l.LessonText
                                 });
                    foreach (var item in query)
                    {
                        SubjectLessonDto subjectLessonDto = new SubjectLessonDto();
                        subjectLessonDto.SubjectLessonID = item.SubjectLessonID;
                        subjectLessonDto.subjectDto = new SubjectDto();
                        subjectLessonDto.SubjectID = item.SubjectID;
                        subjectLessonDto.subjectDto.SubjectText = item.SubjectText;
                        subjectLessonDto.lessonDto = new LessonDto();
                        subjectLessonDto.LessonID = item.LessonID;
                        subjectLessonDto.lessonDto.LessonText = item.LessonText;
                        list.Add(subjectLessonDto);
                    }
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
      
    }
}
