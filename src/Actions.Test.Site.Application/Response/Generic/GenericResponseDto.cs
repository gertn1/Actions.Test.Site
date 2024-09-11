namespace Actions.Test.Site.Application.Dto.Responses.Generic
{
    public class GenericResponseDto
    {
        public bool IsSuccess { get; set; }

        public GenericResponseDto(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
