namespace CourseManager.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }

        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }

        bool Status { get; set; }
    }
}