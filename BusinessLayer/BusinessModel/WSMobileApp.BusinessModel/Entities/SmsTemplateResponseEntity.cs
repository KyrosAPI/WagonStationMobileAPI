
using System.Collections.Generic;

namespace WSMobileApp.BusinessModel.Entities
{
    public sealed class SmsTemplateResponseEntity
    {
        /// <summary>
        /// Gets or sets the templates.
        /// </summary>
        /// <value>
        /// The templates.
        /// </value>
        public List<SmsTemplateEntity> Templates { get; set; }

    }
}
