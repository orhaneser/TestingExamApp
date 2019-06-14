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
   public class UserQuestionLogic
    {
        public ResultHelper AddUserQuestion(UserQuestionDto userQuestionDto)
        {
            try
            {
                UserQuestion item = new UserQuestion();
                item.UserQuestionID = userQuestionDto.UserQuestionID;
                item.UserID = userQuestionDto.UserID;
                item.QuestionID = userQuestionDto.QuestionID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<UserQuestion>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserQuestionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserQuestion(UserQuestionDto userQuestionDto)
        {
            try
            {
                UserQuestion item = new UserQuestion();
                item.UserQuestionID = userQuestionDto.UserQuestionID;
                item.UserID = userQuestionDto.UserID;
                item.QuestionID = userQuestionDto.QuestionID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<UserQuestion>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserQuestionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserQuestion(int userQuestionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<UserQuestion>().GetById(x => x.UserQuestionID == userQuestionID);
                    unitofWork.GetRepository<UserQuestion>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, userQuestionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userQuestionID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserQuestionDto GetUserQuestion(int userQuestionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    UserQuestion item = new UserQuestion();
                    item = unitofWork.GetRepository<UserQuestion>().GetById(x => x.UserQuestionID == userQuestionID);
                    UserQuestionDto userQuestionDto = new UserQuestionDto();
                    userQuestionDto.UserQuestionID = item.UserQuestionID;
                    userQuestionDto.UserID = item.UserID;
                    userQuestionDto.QuestionID =item.QuestionID;

                    return userQuestionDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserQuestionDto> GetAllUserQuestion()
        {
            try
            {
                List<UserQuestionDto> list = new List<UserQuestionDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    
                    var query = (from uq in unitofWork.GetRepository<UserQuestion>().Select(null, null)
                                 join u in unitofWork.GetRepository<User>().Select(null, null) on uq.UserID equals u.UserID
                                 join q in unitofWork.GetRepository<Question>().Select(null, null) on uq.QuestionID equals q.QuestionID
                                 join o in unitofWork.GetRepository<Option>().Select(null, null) on q.OptionID equals o.OptionID
                                 join s in unitofWork.GetRepository<Subject>().Select(null, null) on q.SubjectID equals s.SubjectID

                                 select new
                                 {
                                     UserQuestionID = uq.UserQuestionID,
                                     UserID = u.UserID,
                                     QuestionID = q.QuestionID,
                                     QText = q.QuestionText,
                                     QSubtext = q.SubText,
                                     QDifficult = q.Difficult,
                                     Answer = q.AnswerKey,
                                     oID=o.OptionID,
                                     oA=o.OptionA,
                                     oB=o.OptionB,
                                     oC=o.OptionC,
                                     oD=o.OptionD,
                                     oE=o.OptionE,
                                     subText= s.SubjectText,
                                     subID=s.SubjectID

                                 });
                    foreach (var item in query)
                    {
                        UserQuestionDto userQuestionDto = new UserQuestionDto();
                        userQuestionDto.UserQuestionID = item.UserQuestionID;
                        userQuestionDto.userDto = new UserDto();
                        userQuestionDto.UserID = item.UserID;
                        userQuestionDto.questionDto = new QuestionDto();
                        userQuestionDto.QuestionID = item.QuestionID;
                        userQuestionDto.questionDto.QuestionText = item.QText;
                        userQuestionDto.questionDto.Difficult = item.QDifficult;
                        userQuestionDto.questionDto.SubText = item.QSubtext;
                        userQuestionDto.questionDto.AnswerKey = item.Answer;
                        userQuestionDto.optionDto = new OptionDto();
                        userQuestionDto.optionDto.OptionID = item.oID;
                        userQuestionDto.optionDto.OptionA = item.oA;
                        userQuestionDto.optionDto.OptionB = item.oB;
                        userQuestionDto.optionDto.OptionC = item.oC;
                        userQuestionDto.optionDto.OptionD = item.oD;
                        userQuestionDto.optionDto.OptionE = item.oE;
                        userQuestionDto.subjectDto = new SubjectDto();
                        userQuestionDto.subjectDto.SubjectText = item.subText;
                        userQuestionDto.subjectDto.SubjectID = item.subID ;

                        list.Add(userQuestionDto);
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
