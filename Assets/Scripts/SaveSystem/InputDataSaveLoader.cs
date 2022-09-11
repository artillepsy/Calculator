using Constants;

namespace SaveSystem
{
    public static class InputDataSaveLoader
    {
        public static string LoadInputData()
        {
            var inputData = SaveLoadUtils.Load<UserInputData>(Literals.FileName);
            return inputData == null ? string.Empty : inputData.Data;
        }

        public static void SaveInputData(string text)
        {
            var inputData = new UserInputData(text);
            SaveLoadUtils.Save(inputData, Literals.FileName);
        }
    }
}