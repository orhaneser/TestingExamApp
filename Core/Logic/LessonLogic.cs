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
   public class LessonLogic
    {
        public ResultHelper AddLesson(LessonDto lessonDto)
        {
            try
            {
                Lesson item = new Lesson();
                item.LessonID = lessonDto.LessonID;
                item.LessonText = lessonDto.LessonText;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Lesson>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.LessonID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetLesson(LessonDto lessonDto)
        {
            try
            {
                Lesson item = new Lesson();
                item.LessonID = lessonDto.LessonID;
                item.LessonText = lessonDto.LessonText;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Lesson>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.LessonID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, lessonDto.LessonID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelLesson(int LessonID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<Lesson>().GetById(x => x.LessonID == LessonID);
                    unitofWork.GetRepository<Lesson>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.LessonID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, LessonID, ResultHelper.UnSuccessMessage);

            }
        }
        public LessonDto GetLesson(int LessonID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    Lesson item = new Lesson();
                    item = unitofWork.GetRepository<Lesson>().GetById(x => x.LessonID == LessonID);
                    LessonDto lessonDto = new LessonDto();
                    lessonDto.LessonID = item.LessonID;
                    lessonDto.LessonText = item.LessonText;

                    return lessonDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<LessonDto> GetAllLesson()
        {
            try
            {
                List<LessonDto> list = new List<LessonDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<Lesson> collection = unitofWork.GetRepository<Lesson>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        LessonDto lessonDto = new LessonDto();
                        lessonDto.LessonID = item.LessonID;
                        lessonDto.LessonText = item.LessonText;
                        list.Add(lessonDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<LessonDto>();
            }
        }


    }
}
