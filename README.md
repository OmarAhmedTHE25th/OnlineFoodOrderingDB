# Online Food Ordering Database System

## Project Setup
### Connect the DB to your IDE
1. Go to https://neon.com
2. Make an account, and send me the email you used.
3. In your IDE connect to the DB with this connection string:  
``` postgresql://neondb_owner:npg_MQDhp5uofCe7@ep-still-snow-amau45ls-pooler.c-5.us-east-1.aws.neon.tech/neondb?sslmode=require&channel_binding=require ```  
   If you need to enter the connection string manually, use the following parameters:  
   Host: ep-still-snow-amau45ls-pooler.c-5.us-east-1.aws.neon.tech  
   Port: 5432  
   Database: neondb  
   User: neondb_owner  
   Password: npg_MQDhp5uofCe7  

## Project Organization
- The folders in this repository are divided as per the agreed upon tasks. Each folder corresponds to a specific module or feature of the system.
- **Do not send code on WhatsApp.** All code changes must be pushed to this repository.

## Git Guide (Pushing Code)
Follow these steps to push your changes to the repository:
1. **Stage your changes:**
   `git add .`
2. **Commit your changes:**
   `git commit -m "Your descriptive commit message"`
3. **Pull the latest changes (to avoid conflicts):**
   `git pull origin main`
4. **Push your changes:**
   `git push origin main`

## UI Layout Consistency
To ensure a consistent look and feel across all forms, each form should follow this layout:
- **Data Grid View:** Used for displaying records from the database.
- **Buttons in a Table Layout Panel:** All action buttons (Insert, Update, Delete, etc.) should be organized within a `TableLayoutPanel`.
- **Text Box:** Used for History Logs of Actions taken.

## UI Descriptions
### MenuUI
`MenuUI` is the interface for managing the food items available in the system. It allows users to view, insert, update, and delete menu items. It also displays which special offers are associated with each item.

### OffersUI
`OffersUI` is the interface for managing special offers. It allows users to view, insert, update, and delete offers. Additionally, it provides functionality to manage which menu items are included in a specific special offer.

