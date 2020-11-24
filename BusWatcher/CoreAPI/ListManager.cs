
using DataAcess.Crud;
using Entities_POJOS;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ListManager : BaseManager
    {
        private Dictionary<string, List<OptionList>> dicListOptions;
        private static ListManager _instance;
        //private ListCrudFactory crudCustomer;

        private ListManager()
        {
            LoadDictionary();
            //crudCustomer = new ListCrudFactory();
        }

        public static ListManager GetInstance()
        {
            if (_instance == null)
                _instance = new ListManager();

            return _instance;
        }


        private void LoadDictionary()
        {
            dicListOptions = new Dictionary<string, List<OptionList>>();
            //TODO: ESTO DEBE VENIR DE ELA BASE DE DATOS
            var crudList = new ListOptionCrudFactory();

            var lists = crudList.RetrieveAll<OptionList>();

            if (lists.Count>0)
            {
                var lstId = lists[0].ListId;
                var lstOptions = new List<OptionList>();

                for (int i = 0; i < lists.Count; i++)
                {
                    var l = lists[i];
                    lstOptions.Add(new OptionList { ListId = l.ListId, Value = l.Value, Description = l.Description });

                    if (i == lists.Count - 1 || !lists[i + 1].ListId.Equals(l.ListId))
                    {
                        dicListOptions[l.ListId] = lstOptions;
                        lstOptions = new List<OptionList>();
                        lstId = l.ListId;
                    }

                }
            }
            
        }

        public List<OptionList> RetrieveById(OptionList option)
        {

            try
            {
                if (dicListOptions.ContainsKey(option.ListId))
                {
                    return dicListOptions[option.ListId];
                }
                else
                {
                    //    //BUSCA EN OTRO MANAGER
                    if (option.ListId.Equals("TROL"))
                    {
                        var crudRol = new RolCrudFactory();
                        var lst = crudRol.RetrieveAll<Rol>();

                        var lstResult = new List<OptionList>();

                        foreach (var c in lst)
                        {
                            if (c.estadoRol.Equals("Activo"))
                            {
                                var newOption = new OptionList
                                {
                                    ListId = option.ListId,
                                    Value = c.nombreRol,
                                    Description = c.idRol.ToString()
                                };
                                lstResult.Add(newOption);
                            }
                            
                        }
                        return lstResult;

                    }
                    
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<OptionList>(); ;
        }


    }
}
