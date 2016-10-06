using System.Linq;
using System.Collections.Generic;
using Core.Models;
using System;

namespace Core.Fake
{
	public class ContactFake
	{
		private static List<ContactModel> _data;

		public static List<ContactModel> GetAll()
		{
			if (_data == null)
			{
				_data = new List<ContactModel>();
				_data.Add(new ContactModel()
				{
					Id = "1",
					Name = "Nome 1",
					Profession = "Profissão 1",
					City = "Cidade 1"
				});

				_data.Add(new ContactModel()
				{
					Id = "2",
					Name = "Nome 2",
					Profession = "Profissão 2",
					City = "Cidade 2"
				});

				_data.Add(new ContactModel()
				{
					Id = "3",
					Name = "Nome 3",
					Profession = "Profissão 3",
					City = "Cidade 3"
				});
			}

			return _data;
		}

		public static List<ContactModel> Search(string searchText)
		{
			return _data.Where(d => d.Name.Contains(searchText)).ToList();
		}

		public static void Save(ContactModel model)
		{
			model.Id = Guid.NewGuid().ToString();
			_data.Add(model);
		}

		public static void Update(ContactModel model)
		{
			ContactModel contactModel = _data.Where(d => d.Id == model.Id).FirstOrDefault();

			_data.Remove(contactModel);
			_data.Add(model);
		}

		public static ContactModel GetById(string id)
		{
			return _data.Where(d => d.Id == id).FirstOrDefault();
		}
	}
}
