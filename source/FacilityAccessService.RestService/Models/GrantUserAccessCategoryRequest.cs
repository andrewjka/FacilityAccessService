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
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using FacilityAccessService.RestService.Converters;

namespace FacilityAccessService.RestService.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GrantUserAccessCategoryRequest : IEquatable<GrantUserAccessCategoryRequest>
    {
        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [Required]
        [DataMember(Name="CategoryId", EmitDefaultValue=true)]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        [Required]
        [DataMember(Name="StartDate", EmitDefaultValue=true)]
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [Required]
        [DataMember(Name="EndDate", EmitDefaultValue=true)]
        public DateOnly EndDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GrantUserAccessCategoryRequest {\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((GrantUserAccessCategoryRequest)obj);
        }

        /// <summary>
        /// Returns true if GrantUserAccessCategoryRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of GrantUserAccessCategoryRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GrantUserAccessCategoryRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    CategoryId == other.CategoryId ||
                    
                    CategoryId.Equals(other.CategoryId)
                ) && 
                (
                    StartDate == other.StartDate ||
                    
                    StartDate.Equals(other.StartDate)
                ) && 
                (
                    EndDate == other.EndDate ||
                    
                    EndDate.Equals(other.EndDate)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    hashCode = hashCode * 59 + CategoryId.GetHashCode();
                    
                    hashCode = hashCode * 59 + StartDate.GetHashCode();
                    
                    hashCode = hashCode * 59 + EndDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(GrantUserAccessCategoryRequest left, GrantUserAccessCategoryRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GrantUserAccessCategoryRequest left, GrantUserAccessCategoryRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
