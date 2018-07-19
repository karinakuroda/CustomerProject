﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public abstract class Entity
	{
		private DateTime _created;
		private DateTime _updated;


		public DateTime Created
		{
			get
			{
				return _created != DateTime.MinValue ? _created : DateTime.Now;
			}
			set
			{
				_created = value;
			}
		}


		public DateTime Updated
		{
			get
			{
				return _updated != DateTime.MinValue ? _updated : DateTime.Now;
			}
			set
			{
				_updated = value;
			}
		}
	}
}
