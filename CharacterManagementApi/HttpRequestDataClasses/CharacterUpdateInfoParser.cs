using System;
using System.Collections.Generic;

namespace CharacterManagementApi.HttpRequestDataClasses
{

    public class CharacterUpdateInfoParser 
    {

        public List<string> UpdateNames {get; set;}

        public List<string> UpdateAttributes {get; set;}

        public List<string> UpdateNewValues {get; set;}

        public CharacterUpdateInfoWrapper UpdateInfo {get; set;}

        public CharacterUpdateInfoParser(CharacterUpdateInfoWrapper updateInfo) 
        {
            this.UpdateInfo = updateInfo;

            this.UpdateNames = new List<string>();

            this.UpdateAttributes = new List<string>();

            this.UpdateNewValues = new List<string>();

        }

        public void ParseUpdateInfo() 
        {

            for (int i = 0; i < UpdateInfo.DynamicUpdateInfo.Length; i++)
            {

                string update = this.UpdateInfo.DynamicUpdateInfo[i];

                string[] updateDetails = update.Split("_");

                this.UpdateNames.Add(updateDetails[0]);

                this.UpdateAttributes.Add(updateDetails[1]);

                this.UpdateNewValues.Add(updateDetails[2]);
            }
        }
    
    }
}