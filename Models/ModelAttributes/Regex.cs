﻿namespace Models.ModelAttributes
{
    public class Regex
    {
        public const string Email = @"\A(?:[a-zA-Z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?)\Z";
        public const string NoWthispace = @"^\S*$";
        public const string ValidPassword = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).*";
    }
}
