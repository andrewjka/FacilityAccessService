/*
 * Facility Access Service API
 *
 * The service an access control system for facilities within the enterprise territory.
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace FacilityAccessService.RestService.Models
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class GrantUserAccessFacilityRequest : IEquatable<GrantUserAccessFacilityRequest>
    {
        /// <summary>
        ///     Gets or Sets UserId
        /// </summary>
        [Required]
        [DataMember(Name = "UserId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        /// <summary>
        ///     Gets or Sets FacilityId
        /// </summary>
        [Required]
        [DataMember(Name = "FacilityId", EmitDefaultValue = true)]
        public Guid FacilityId { get; set; }

        /// <summary>
        ///     Gets or Sets StartDate
        /// </summary>
        [Required]
        [DataMember(Name = "StartDate", EmitDefaultValue = true)]
        public DateOnly StartDate { get; set; }

        /// <summary>
        ///     Gets or Sets EndDate
        /// </summary>
        [Required]
        [DataMember(Name = "EndDate", EmitDefaultValue = true)]
        public DateOnly EndDate { get; set; }

        /// <summary>
        ///     Returns true if GrantUserAccessFacilityRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of GrantUserAccessFacilityRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GrantUserAccessFacilityRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    UserId == other.UserId ||
                    (UserId != null &&
                     UserId.Equals(other.UserId))
                ) &&
                (
                    FacilityId == other.FacilityId ||
                    FacilityId.Equals(other.FacilityId)
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
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GrantUserAccessFacilityRequest {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  FacilityId: ").Append(FacilityId).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
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
            return obj.GetType() == GetType() && Equals((GrantUserAccessFacilityRequest)obj);
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
                if (UserId != null)
                    hashCode = hashCode * 59 + UserId.GetHashCode();

                hashCode = hashCode * 59 + FacilityId.GetHashCode();

                hashCode = hashCode * 59 + StartDate.GetHashCode();

                hashCode = hashCode * 59 + EndDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(GrantUserAccessFacilityRequest left, GrantUserAccessFacilityRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GrantUserAccessFacilityRequest left, GrantUserAccessFacilityRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}