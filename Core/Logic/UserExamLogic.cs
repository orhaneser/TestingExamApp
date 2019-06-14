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
  public  class UserExamLogic
    {
        public ResultHelper AddUserExam(UserExamDto userExamDto)
        {
            try
            {
                UserExam item = new UserExam();
                item.UserExamID = userExamDto.UserExamID;
                item.ExamID = userExamDto.ExamID;
                item.UserID = userExamDto.UserID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<UserExam>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserExamID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserExam(UserExamDto userExamDto)
        {
            try
            {
                UserExam item = new UserExam();
                item.UserExamID = userExamDto.UserExamID;
                item.UserID = userExamDto.UserID;
                item.ExamID = userExamDto.ExamID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<UserExam>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserExamID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserExam(int userExamID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<UserExam>().GetById(x => x.UserExamID == userExamID);
                    unitofWork.GetRepository<UserExam>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, userExamID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userExamID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserExamDto GetUserExam(int userExamID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    UserExam item = new UserExam();
                    item = unitofWork.GetRepository<UserExam>().GetById(x => x.UserExamID == userExamID);
                    UserExamDto userExamDto = new UserExamDto();
                    userExamDto.UserExamID = item.UserExamID;
                    userExamDto.UserID = (int)item.UserID;
                    userExamDto.ExamID = (int)item.ExamID;

                    return userExamDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserExamDto> GetAllUserExam()
        {
            try
            {
                List<UserExamDto> list = new List<UserExamDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from ue in unitofWork.GetRepository<UserExam>().Select(null, null)
                                 join e in unitofWork.GetRepository<Exam>().Select(null, null) on ue.ExamID equals e.ExamID
                                 join u in unitofWork.GetRepository<User>().Select(null, null) on ue.UserID equals u.UserID
                                 select new
                                 {
                                     userExamID = ue.UserExamID,
                                     userID = u.UserID,
                                     examID = e.ExamID,
                                     exam = e.Exam1,

                                 });
                    foreach (var item in query)
                    {
                        UserExamDto userExamDto = new UserExamDto();
                        userExamDto.UserExamID = item.userExamID;
                        userExamDto.userDto = new UserDto();
                        userExamDto.UserID = item.userID;
                        userExamDto.examDto = new ExamDto();
                        userExamDto.ExamID = item.examID;
                        userExamDto.examDto.Exam = item.exam;
                        list.Add(userExamDto);
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
