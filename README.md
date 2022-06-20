## Тестовое задание в компании X

#### Introduction
This assignment is simple but not trivial and will take some time to complete. Completed assignment should be presented as working WPF application displaying a long list of searchable and selectable hierarchical entries.

#### Specificaion

###### Application panel is a small window with three controls:
- Tree view, 
- Load button
- Input text box for filter string. 
User can exit application by closing main window using standard windows frame button.

###### Tree view is a two-level tree.
- Top level items are named as CategoryXXX, where XXX is sequential number starting from 1 (there shouldn’t be two top-level items with same number).
- Initial number of Categories is 25 
- Categories are arranged according to the increasing category number (natural order of date generation, no need for sorting)
- Each category has between 1 to 10 second level items named as ItemYY, where YY is number from 1 to 30; - like Item5, Item28, Item30. Numbers should not be continuous or even increasing – they indeed form a random sequence. All Items within same category should have different numbers (items belonging to different categories may have same number).
- If the view cannot accommodate all items – the slider bar is added on its right edge.

###### Application Startup
Upon application start, the tree is empty

###### Load Button
Upon hitting the Load button, number of categories is increased by 25 and complete data structure is rebuilt fresh. For example, second load will result in 50 categories. 
To simulate real world scenario, tree structure computation will execute asynchronously to the main thread. If new tree structure contains item that was previously selected in the UI, after load operation is complete the same item need to be selected. Items are the same if there name are the same. If such item does not exist in a new structure no item is selected in UI.

###### Filter Input Box
Upon clicking into the input box user can type any free string
Upon clicking outside input box – it becomes unresponsive to typing
As user types, tree view should refresh (immediately or after slight delay) to show only reduced set of categories and items filtered by these rules:
- Entered text is used for substring case insensitive match against title of the categories and items. For example:
	- input texts “Ca”, “go”, “ego” matches all categories
	- Input texts “e”, “Te” matches all items and all categories
	- Input text “RY2” matches Category2, Category23, Category238, and so on
	- Input text “tEm3” matches Item3, Item30
- If input text matches some of the categories:
	- all branches respecting to those categories are displayed and fully opened showing all their items
	- The Category name is displayed in GREEN
	- All items are displayed in BLACK
- If input text matches some of the items (say input “em2”):
	- Each category containing matching item is shown on reduced tree
	- Among second level items only those that match the typed string are shown (say Item2, Item23)
	- Other items that doesn’t match the string (say Item7, Item14, Item30) are not shown
	- Matching items are shown in GREEN
	- Hosting category is shown in BLACK
- If input string matches both – categories and items within same category (say string “e”):
	- Both rules are applied in parallel
	- Categories that match the string shown in GREEN, others in BLACK
	- Items that match the string are shown in GREEN, others in BLACK

###### Selection on the tree control
- Clicking anywhere within tree control causes selection of the item lined up with the cursor position
- Selected item should be highlighted
- By default, WPF tree view control highlights only text (content) of a selected item. In this application, selected category or item should be highlighted from left to right rim of the tree view box as shown on illustration). This is called full line highlight.