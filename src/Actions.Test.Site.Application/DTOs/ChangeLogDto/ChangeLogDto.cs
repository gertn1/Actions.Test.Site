namespace Actions.Test.Site.Application.DTOs.ChangeLogDto
{
    public class ChangeLogDto<T>
    {
        public T Before { get; set; }
        public T After { get; set; }
    }
}
