using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}