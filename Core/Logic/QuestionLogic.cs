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
   public class QuestionLogic
    {
        public ResultHelper AddQuestion(QuestionDto questionDto)
        {
            try
            {
                Question item = new Question();
                item.QuestionID = questionDto.QuestionID;
                item.QuestionText = questionDto.QuestionText;
                item.Difficult = questionDto.Difficult;
                item.SubjectID = questionDto.SubjectID;
                item.SubText = questionDto.SubText;
                item.AnswerKey = questionDto.AnswerKey;
                item.OptionID = questionDto.OptionID;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Question>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.QuestionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetQuestion(QuestionDto questionDto)
        {
            try
            {
                Question item = new Question();
                item.QuestionID = questionDto.QuestionID;
                item.QuestionText = questionDto.QuestionText;
                item.SubText = questionDto.SubText;
                item.Difficult = questionDto.Difficult;
                item.AnswerKey = questionDto.AnswerKey;
                item.OptionID = questionDto.OptionID;
                item.SubjectID = questionDto.SubjectID;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Question>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.QuestionID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, questionDto.QuestionID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelQuestion(int QuestionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<Question>().GetById(x => x.QuestionID == QuestionID);
                    unitofWork.GetRepository<Question>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.QuestionID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, QuestionID, ResultHelper.UnSuccessMessage);

            }
        }
        public QuestionDto GetQuestion(int QuestionID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    Question item = new Question();
                    item = unitofWork.GetRepository<Question>().GetById(x => x.QuestionID == QuestionID);
                    QuestionDto questionDto = new QuestionDto();
                    questionDto.QuestionID = item.QuestionID;
                    questionDto.QuestionText = item.QuestionText;
                    questionDto.SubText = item.SubText;
                    questionDto.Difficult = item.Difficult;
                    questionDto.SubjectID = (int)item.SubjectID;
                    questionDto.OptionID =(int) item.OptionID;

                    return questionDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<QuestionDto> GetAllQuestion()
        {
            try
            {
                List<QuestionDto> list = new List<QuestionDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<Question> collection = unitofWork.GetRepository<Question>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        QuestionDto questionDto = new QuestionDto();
                        questionDto.QuestionID = item.QuestionID;
                        questionDto.QuestionText = item.QuestionText;
                        questionDto.OptionID = item.OptionID.Value;
                        questionDto.SubjectID = item.SubjectID.Value;
                        questionDto.Difficult = item.Difficult;
                        questionDto.SubText = item.SubText;
                        // yukarısının aynısını diğer bağlı tablolar içinde yap bilgiler gelsin
                        list.Add(questionDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<QuestionDto>();
            }
        }
    }
}
