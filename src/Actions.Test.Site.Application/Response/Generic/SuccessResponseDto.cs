namespace Actions.Test.Site.Application.Dto.Responses.Generic
{
    public class SuccessResponseDto : GenericResponseDto
    {
        public object Data { get; set; }

        public SuccessResponseDto(object data) : base(true)
        {
            Data = data;
        }
    }
}
