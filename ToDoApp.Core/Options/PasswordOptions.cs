using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Options
{
    public class PasswordOptions
    {
        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a digit. 
        /// </summary>
        public bool RequireDigit { get; set; }

        /// <summary>
        /// Gets or sets the minimum length a password must be.
        /// </summary>
        public int RequiredLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of unique characters which a password must contain.
        /// </summary>
        public int RequiredUniqueChars { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a lower case ASCII character.
        /// </summary>
        public bool RequireLowercase { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a non-alphanumeric character.
        /// </summary>
        public bool RequireNonAlphanumeric { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a upper case ASCII character.
        /// </summary>
        public bool RequireUppercase { get; set; }
    }
}
