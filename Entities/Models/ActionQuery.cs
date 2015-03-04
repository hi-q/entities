using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entities.Models
{
    public abstract class ActionQuery : IValidatableObject
    {
        public string Action { get; set; }

        public string Id { get; set; }

        public IEnumerable<long> ProductsIds
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    return new long[] {};
                }

                var isParsed = true;

                var ids = Id.Split(",".ToCharArray()).Select(str =>
                {
                    long id;

                    if (long.TryParse(str, out id))
                    {
                        return id;
                    }

                    isParsed = false;
                    return 0;
                });

                return !isParsed ? new long[] {} : ids;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id != null && Id.Any()) return new ValidationResult[] {};

            var validationResult = new ValidationResult("One or more items are required");
            return new [] {validationResult};
        }
    }
}