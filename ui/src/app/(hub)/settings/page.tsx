import { UserProfile } from "@clerk/nextjs";

export default function SettingsPage() {
  return (
    <div className="mt-5">
      <UserProfile routing="hash"  />
    </div>
  )
}