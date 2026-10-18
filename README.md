# StudentManagement

## 待改進

重讀程式碼時確認到以下問題：

1. **刪除永遠刪到第一筆**：`Presenters/StudentPresenter.cs` 的 `AddStudent` 建立 `StudentDTO` 時沒有指定 `Id`，所有 DTO 的 `Id` 都是 `Guid.Empty`；`Student` 物件也從未設定 `Id`。`DeleteStudent` 用 `this.students.First(x => x.Id == student.Id)` 尋找，條件對每一筆都成立，結果不論按哪一張卡片的刪除，都會刪掉清單中的第一筆。修正方向：`AddStudent` 時給 `Id = Guid.NewGuid()`，並在轉成 `Student` 時一併帶過去。
2. **體重被身高覆蓋、Id 沒帶回畫面**：`MainViewModel.cs` 的 `OnAddStudent` 與 `OnDeleteStudent` 都寫成 `new Student(d.Name, d.Age, d.Height, d.Height)`，第四個參數應該是 `d.Weight`，所以畫面上的體重永遠顯示成身高；同時也沒有把 `d.Id` 指定給 `Student`，即使修好第 1 點，刪除時傳回 Presenter 的 Id 仍是空的。
3. **編輯後的資料沒有存回 Presenter**：`StudentPresenter.SaveStudent` 只呼叫 `OnSaveStudent` 切換 `IsEditable` / `IsSavable`，沒有更新 Presenter 持有的 `StudentDTO` 清單。之後只要新增或刪除，`OnAddStudent` / `OnDeleteStudent` 會從 DTO 清單重建整個 `students`，先前編輯過的內容就被還原。
4. **輸入未驗證就 Parse**：`AddStudent` 直接 `int.Parse(age)`、`float.Parse(height)`、`float.Parse(weight)`。欄位空白（屬性為 null）或輸入非數字時會丟出例外，而 Command 裡沒有任何處理，程式會直接結束。可以改用 `TryParse`，失敗時透過 View 回呼顯示錯誤訊息。
