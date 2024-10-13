"use client";

import { Button } from "@/components/ui/button";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { HandCoins } from "lucide-react";

interface MakeOfferDialogProps {
    onSubmit: (e: React.FormEvent) => void
    offerAmount: string
    setOfferAmount: React.Dispatch<React.SetStateAction<string>>,
    playerName: string;
}

export default function MakeOfferDialog({ playerName, onSubmit, offerAmount, setOfferAmount }: MakeOfferDialogProps) {

    return (
        <Dialog>
            <DialogTrigger asChild>
                <Button variant="outline" className="flex gap-x-2">
                    <HandCoins /> Make Offer
                </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-[425px]">
                <DialogHeader>
                    <DialogTitle>Make an Offer for {playerName}</DialogTitle>
                </DialogHeader>
                <form onSubmit={onSubmit} className="grid gap-4 py-4">
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="amount" className="text-right">
                            Offer (£)
                        </Label>
                        <Input
                            id="amount"
                            type="number"
                            value={offerAmount}
                            min={0}
                            step={0.01}
                            max={1000}
                            onChange={(e) => setOfferAmount(e.target.value)}
                            className="col-span-3"
                            placeholder="Enter your offer amount"
                        />
                    </div>
                    <Button type="submit" className="ml-auto">
                        Submit Offer
                    </Button>
                </form>
            </DialogContent>
        </Dialog>
    )
}