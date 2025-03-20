/*
 * Facility Access Service API
 *
 * The service an access control system for facilities within the enterprise territory.
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace FacilityAccessService.RestService.Models
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class Category : IEquatable<Category>
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Facilities
        /// </summary>
        [DataMember(Name = "Facilities", EmitDefaultValue = false)]
        public List<Facility> Facilities { get; set; }

        /// <summary>
        ///     Returns true if Category instances are equal
        /// </summary>
        /// <param name="other">Instance of Category to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Category other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    (Id != null &&
                     Id.Equals(other.Id))
                ) &&
                (
                    Name == other.Name ||
                    (Name != null &&
                     Name.Equals(other.Name))
                ) &&
                (
                    Facilities == other.Facilities ||
                    (Facilities != null &&
                     other.Facilities != null &&
                     Facilities.SequenceEqual(other.Facilities))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Category {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Facilities: ").Append(Facilities).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Category)obj);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Facilities != null)
                    hashCode = hashCode * 59 + Facilities.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(Category left, Category right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Category left, Category right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}